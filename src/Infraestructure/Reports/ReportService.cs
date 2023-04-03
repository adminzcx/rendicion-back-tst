using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using Prome.Viaticos.Server.Domain.Enums;
using System.Collections.Generic;
using System.Net;
using ReportExecuteType = AspNetCore.Report.ReportExecuteType;
using ReportRenderType = AspNetCore.Report.ReportRenderType;
using ReportRequest = AspNetCore.Report.ReportRequest;
using ReportSettings = AspNetCore.Report.ReportSettings;
using ReportViewer = AspNetCore.Report.ReportViewer;

namespace Prome.Viaticos.Server.Infraestructure.Reports
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;
        public IHostingEnvironment Hosting;
        public ReportService(
            IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            Hosting = hostingEnvironment;
        }

        public byte[] GenerateExpenseReport(FolderPathEnum path, ExpenseFormDto expenseForm)
        {

            var parameters = new Dictionary<string, string>
            {
                { "User", expenseForm.User },
                { "RequestNumber", expenseForm.EmployeeRecord },
                { "ExpenseFormId", expenseForm.Id.ToString() },
                { "ExpenseFormDate", expenseForm.PresentationDate.ToShortDateString() }
            };

            var reportUser = _configuration["MySettings:ReportServerUser"];
            var reportPass = _configuration["MySettings:ReportServerPass"];
            var reportDomain = _configuration["MySettings:ReportServerDomain"];
            var rv = new ReportViewer(new ReportSettings()
            {
                ReportServer = _configuration["MySettings:ReportServerUrl"],
                Credential = new NetworkCredential(reportUser, reportPass, reportDomain),
                UserAgent = "",
                ShowToolBar = true
            });
            var result = rv.Execute(new ReportRequest()
            {
                ExecuteType = ReportExecuteType.Export,
                RenderType = ReportRenderType.Pdf,
                Path = _configuration["MySettings:ExpenseFormPath"],
                Parameters = parameters
            });

            return result.Data.Stream;
        }

        public byte[] GenerateLunchReport(FolderPathEnum path, LunchFormForEditDto lunchForm)
        {
            var parameters = new Dictionary<string, string>
            {
                { "User", lunchForm.User },
                { "RequestNumber", lunchForm.LunchFormNumber },
                { "LunchFormId", lunchForm.Id.ToString() },
                { "ExpenseFormDate", lunchForm.Date.ToShortDateString() }
            };

            var reportUser = _configuration["MySettings:ReportServerUser"];
            var reportPass = _configuration["MySettings:ReportServerPass"];
            var reportDomain = _configuration["MySettings:ReportServerDomain"];
            var rv = new ReportViewer(new ReportSettings()
            {
                ReportServer = _configuration["MySettings:ReportServerUrl"],
                Credential = new NetworkCredential(reportUser, reportPass, reportDomain),
                UserAgent = "",
                ShowToolBar = true
            });
            var result = rv.Execute(new ReportRequest()
            {
                ExecuteType = ReportExecuteType.Export,
                RenderType = ReportRenderType.Pdf,
                Path = _configuration["MySettings:LunchFormPath"],
                Parameters = parameters
            });

            return result.Data.Stream;
        }

        public byte[] GenerateCashReport(FolderPathEnum path, CashFormDto cashForm)
        {
            var parameters = new Dictionary<string, string>
            {
                { "User", cashForm.User.FirstName + " " + cashForm.User.LastName },
                { "RequestNumber", cashForm.User.EmployeeRecord },
                { "CashFormId", cashForm.Id.ToString()},
                { "CashFormDate", cashForm.Period }
            };

            var reportUser = _configuration["MySettings:ReportServerUser"];
            var reportPass = _configuration["MySettings:ReportServerPass"];
            var reportDomain = _configuration["MySettings:ReportServerDomain"];
            var rv = new ReportViewer(new ReportSettings()
            {
                ReportServer = _configuration["MySettings:ReportServerUrl"],
                Credential = new NetworkCredential(reportUser, reportPass, reportDomain),
                UserAgent = "",
                ShowToolBar = true
            });
            var result = rv.Execute(new ReportRequest()
            {
                ExecuteType = ReportExecuteType.Export,
                RenderType = ReportRenderType.Pdf,
                Path = _configuration["MySettings:CashFormPath"],
                Parameters = parameters
            });

            return result.Data.Stream;
        }

        public string GetMimeType()
        {
            return "application/pdf";
        }

    }
}
