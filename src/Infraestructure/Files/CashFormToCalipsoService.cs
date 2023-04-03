using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using System.IO;
using System.Linq;
using Prome.Viaticos.Server.Infraestructure.Logging;

namespace Prome.Viaticos.Server.Infraestructure.Files
{
    class CashFormToCalipsoService : ICashFormToCalipsoService
    {
        private readonly IConfiguration _configuration;
        public IHostingEnvironment Hosting;

        public CashFormToCalipsoService(
            IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            Hosting = hostingEnvironment;
        }


        public byte[] GetExcelFile(CashFormDto cashForm)
        {
            var report = _configuration["MySettings:CalipsoCashTemplate"];
            AppStaticLogInfraestucture.Information(report);
            
            
            
            FileInfo file = new FileInfo(report);
            AppStaticLogInfraestucture.Information("Reading Excel File");


            using var package = new ExcelPackage(file);
            ExcelWorkbook workBook = package.Workbook;
            ExcelWorksheet currentWorksheet = workBook.Worksheets.SingleOrDefault(w => w.Name == "Rendición");

            AppStaticLogInfraestucture.Information("Reading Excel File: currentWorksheet");

            if (currentWorksheet != null)
            {
                #region Head
                currentWorksheet.Cells["E4"].Value = cashForm.Branch.Name;
                currentWorksheet.Cells["K4"].Value = cashForm.Period;
                currentWorksheet.Cells["F8"].Value = cashForm.User.Name;
                #endregion

                #region Cash
                var row = 15;
                var col = "H";
                currentWorksheet.Cells[col + 15].Value = getCashValue(cashForm, 500, false);
                currentWorksheet.Cells[col + 16].Value = getCashValue(cashForm, 200, false);
                currentWorksheet.Cells[col + 17].Value = getCashValue(cashForm, 100, false);
                currentWorksheet.Cells[col + 18].Value = getCashValue(cashForm, 50, false);
                currentWorksheet.Cells[col + 19].Value = getCashValue(cashForm, 20, false);
                currentWorksheet.Cells[col + 20].Value = getCashValue(cashForm, 10, false);
                currentWorksheet.Cells[col + 21].Value = getCashValue(cashForm, 5, false);
                currentWorksheet.Cells[col + 21].Value = getCashValue(cashForm, 2, false);

                row = 27;
                currentWorksheet.Cells[col + 27].Value = getCashValue(cashForm, 2, true);
                currentWorksheet.Cells[col + 28].Value = getCashValue(cashForm, 1, true);
                currentWorksheet.Cells[col + 29].Value = getCashValue(cashForm, (decimal)0.5, true);
                currentWorksheet.Cells[col + 30].Value = getCashValue(cashForm, (decimal)0.25, true);
                currentWorksheet.Cells[col + 31].Value = getCashValue(cashForm, (decimal)0.10, true);
                currentWorksheet.Cells[col + 32].Value = getCashValue(cashForm, (decimal)0.05, true);
                #endregion


                #region Expenses
                row = 39;

                foreach (var expense in cashForm.Expenses)
                {
                    currentWorksheet.Cells["E" + row].Value = expense.Date.ToShortDateString();
                    currentWorksheet.Cells["F" + row].Value = expense.Vendor;
                    currentWorksheet.Cells["G" + row].Value = expense.CashConcept.Calipso;
                    currentWorksheet.Cells["J" + row].Value = expense.Total;
                    currentWorksheet.Cells["K" + row].Value = expense.CostCenter.Name;
                    row++;
                }
                #endregion

                row = 77;
                currentWorksheet.Cells["J" + row].Value = cashForm.TotalCreditCard;
                currentWorksheet.Cells["J" + (row + 1)].Value = cashForm.TotalPending;
                row = 81;
                currentWorksheet.Cells["J" + row].Value = cashForm.FundTotal;
            }


            var result = file.DirectoryName + "\\" + cashForm.CashFormNumber.ToString() + ".xls";
            var fileResult = new FileInfo(result);
            package.SaveAs(fileResult);
            return File.ReadAllBytes(result);
        }

        private decimal getCashValue(CashFormDto cashForm, decimal value, bool isCoin)
        {
            var result = cashForm.Cashes.SingleOrDefault(X => X.MoneyType.Value == value && X.MoneyType.IsCoin == isCoin);
            if (result != null)
            {
                return result.Amount;
            }
            else
            {
                {
                    return 0;
                }
            }
        }
        public string GetMimeType()
        {
            return "application/vnd.ms-excel";
        }
    }
}
