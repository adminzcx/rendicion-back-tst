using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.LunchAggregate;
using Prome.Viaticos.Server.Infraestructure.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Prome.Viaticos.Server.Infraestructure.Services
{
    class FtpService : IFtpService
    {

        private string ftp;
        private string ftpCalipsoSource;
        private string ftpEdenredSource;
        private string user;
        private string password;
        private string localDestinationPath;
        private string ftpDestinationPath;

        public FtpService(
            IConfiguration configuration)
        {
            var _configuration = configuration;
            ftp = _configuration["FTP:FTPUrl"];
            ftpCalipsoSource = _configuration["FTP:FTPCalipsoSourceFolder"];
            ftpEdenredSource = _configuration["FTP:FTPEdenredSourceFolder"];
            user = _configuration["FTP:FTPUser"];
            password = _configuration["FTP:FTPPass"];
            localDestinationPath = _configuration["FTP:LocalDestinationPath"];
            ftpDestinationPath = _configuration["FTP:FTPDestinationFolder"];
        }

        public async Task<Collection<FileImported>> DownloadExcelFilesFromFtp(FileImportationEnum source)
        {
            try
            {
                var ftpSource = (source == FileImportationEnum.Calipso ? ftpCalipsoSource : ftpEdenredSource);
                AppStaticLogInfraestucture.Information(ftpSource);


                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftp + "/" + ftpSource);
                ftpRequest.Credentials = new NetworkCredential(user, password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream()!);
                var directories = new List<string>();


                var line = await streamReader.ReadLineAsync();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = await streamReader.ReadLineAsync();
                }
                streamReader.Close();


                using var ftpClient = new WebClient { Credentials = new NetworkCredential(user, password) };

                var result = new Collection<FileImported>();
                for (var i = 0; i <= directories.Count - 1; i++)
                {
                    if (!directories[i].Contains(".")) continue;
                    var file = directories[i].Remove(0, directories[i].LastIndexOf("/", StringComparison.Ordinal) + 1);
                    var path = ftp + "/" + ftpSource + "/" + file;
                    var localFileName = localDestinationPath + @"\" + file;


                    ftpClient.DownloadFile(path, localFileName);

                    AppStaticLogInfraestucture.Information("Reading " + localFileName);
                    result = await ReadExcelFile(source, localFileName);
                    AppStaticLogInfraestucture.Information("Total of record imported:" + result.Count().ToString());
                    MoveFileOnFtp(file, localFileName, ftpSource);
                }

                return result;

            }
            catch (WebException e)
            {
                AppStaticLogInfraestucture.Fatal(e, "Download Excel from FTP");
                throw;
            }
        }


        private void MoveFileOnFtp(string file, string localFileName, string ftpSource)
        {
            try
            {


                var destination = ftp + "/" + ftpDestinationPath + "/" + file;
                var source = ftp + "/" + ftpSource + "/" + file;
                AppStaticLogInfraestucture.Information("MoveFile - Destination:" + destination);
                AppStaticLogInfraestucture.Information("MoveFile - Source:" + source);


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destination);
                request.Method = WebRequestMethods.Ftp.UploadFile;


                request.Credentials = new NetworkCredential(user, password);


                byte[] fileContents;
                using (StreamReader sourceStream = new StreamReader(localFileName))
                {
                    fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                }

                request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");

                    FtpWebRequest requestDelete = (FtpWebRequest)WebRequest.Create(source);
                    requestDelete.Method = WebRequestMethods.Ftp.DeleteFile;


                    requestDelete.Credentials = new NetworkCredential(user, password);
                    FtpWebResponse responseDelete = (FtpWebResponse)requestDelete.GetResponse();
                    Console.WriteLine("Delete status: {0}", responseDelete.StatusDescription);
                    responseDelete.Close();

                }

            }
            catch (Exception e)
            {
                AppStaticLogInfraestucture.Fatal(e, "Moving Excel to Done folder");
                throw;
            }
        }
        private async Task<Collection<FileImported>> ReadExcelFile(FileImportationEnum source, string fileName)
        {
            var uploadedFileInfo = new FileInfo(fileName);

            if (uploadedFileInfo.Extension != ".xlsx") return null;
            using ExcelPackage package = new ExcelPackage(uploadedFileInfo);
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];


            AppStaticLogInfraestucture.Information("Reading Excel WorkSheet");


            return source switch
            {
                FileImportationEnum.Calipso => await this.ReadCalipsoFile(workSheet),
                FileImportationEnum.Edenred => await this.ReadEdenredFile(workSheet),
                _ => null
            };
        }


        private async Task<Collection<FileImported>> ReadCalipsoFile(ExcelWorksheet workSheet)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var result = new Collection<FileImported>();


            var rows = workSheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .Skip(1)
                .OrderBy(x => x);

            foreach (var item in rows)
            {
                try
                {
                    var model = new FileImported(workSheet.Cells[item, 1].Value.ToString(),
                        GetDate(workSheet.Cells[item, 5].Value.ToString()),
                        GetDate(workSheet.Cells[item, 6].Value.ToString())
                      );

                    result.Add(model);
                }
                catch (Exception e)
                {
                    AppStaticLogInfraestucture.Fatal(e, "Reading Excel model");
                }

            }
            return result;
        }

        private DateTime GetDate(string cellDate)
        {
            var tmpFile = cellDate.Split('-');
            var day = Convert.ToInt32(tmpFile[0]);
            var month = Convert.ToInt32(tmpFile[1]);
            var year = Convert.ToInt32(tmpFile[2]);
            return new DateTime(year, month, day);
        }
        private DateTime GetEdenredDate(string cellDate)
        {
            var tmpFile = cellDate.Split('/');
            var day = Convert.ToInt32(tmpFile[0]);
            var month = Convert.ToInt32(tmpFile[1]);
            var year = Convert.ToInt32(tmpFile[2]);
            return new DateTime(year, month, day);
        }

        private async Task<Collection<FileImported>> ReadEdenredFile(ExcelWorksheet workSheet)
        {
            var result = new Collection<FileImported>();

            var rows = workSheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .Skip(2)
                .OrderBy(x => x);

            foreach (var item in rows)
            {
                try
                {
                    var model = new FileImported(workSheet.Cells[item, 4].Value.ToString(),
                        GetEdenredDate(workSheet.Cells[item, 5].Value.ToString()),
                        GetEdenredDate(workSheet.Cells[item, 5].Value.ToString())
                    );

                    result.Add(model);
                }
                catch (Exception e)
                {
                    AppStaticLogInfraestucture.Fatal(e, "Reading Excel model");
                }

            }
            return result;
        }
    }


}
