using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Prome.Viaticos.Server.Infraestructure.Files
{
    class ExpenseFormToCalipsoService : IExpenseFormToCalipsoService
    {
        private readonly IConfiguration _configuration;
        public IHostingEnvironment Hosting;

        public ExpenseFormToCalipsoService(
            IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            Hosting = hostingEnvironment;
        }


        public byte[] GetExcelFile(ICollection<ExpenseFormDto> expenseFormList)
        {
            var report = _configuration["MySettings:CalipsoExpenseTemplate"];

            FileInfo file = new FileInfo(report);

            using var package = new ExcelPackage(file);
            ExcelWorkbook workBook = package.Workbook;
            ExcelWorksheet currentWorksheet = workBook.Worksheets[0];


            if (currentWorksheet != null)
            {
                #region Expenses
                int row = 2;
                foreach (var expenseForm in expenseFormList)
                {
                    if(!expenseForm.Expenses.Any()) {continue;}
                    var minDate= expenseForm.Expenses.Min(x => x.ExpenseDate);
                    var maxDate = expenseForm.Expenses.Max(x => x.ExpenseDate);

                    foreach (var expense in expenseForm.Expenses)
                    {
                        currentWorksheet.Cells["A" + row].Value = expenseForm.EmployeeRecord;
                        currentWorksheet.Cells["B" + row].Value = expenseForm.PresentationDate.ToShortDateString();
                        currentWorksheet.Cells["C" + row].Value = expense.Concept;
                        currentWorksheet.Cells["D" + row].Value = expense.ExpenseDate.ToShortDateString();
                        currentWorksheet.Cells["E" + row].Value = 1;
                        currentWorksheet.Cells["F" + row].Value = expense.Amount;
                        currentWorksheet.Cells["G" + row].Value = minDate.ToShortDateString();
                        currentWorksheet.Cells["H" + row].Value = maxDate.ToShortDateString();
                        row++;
                    }
                }
                #endregion
            }

            var result = file.DirectoryName + "\\" + "ExpenseFormExported.xls";
            var fileResult = new FileInfo(result);
            package.SaveAs(fileResult);
            return File.ReadAllBytes(result);

        }

      

        public string GetMimeType()
        {
            return "application/vnd.ms-excel";
        }


    }
}
