using Microsoft.Extensions.Configuration;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.IO;

namespace Prome.Viaticos.Server.Infraestructure.Files
{
    class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(
        IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void UploadFile(FolderPathEnum path, string document, string documentName)
        {

            var convert = document.Replace("data:image/png;base64,", string.Empty)
                                             .Replace("data:image/jpeg;base64,", string.Empty)
                                             .Replace("data:image/bmp;base64,", string.Empty)
                                             .Replace("data:application/pdf;base64,", string.Empty)
                                             .Replace("data:image/jpg;base64,", string.Empty);

            var bytes = Convert.FromBase64String(convert);
            File.WriteAllBytes(this.GetFolderPath(path) + @"\" + documentName, bytes);
        }

        byte[] IFileService.DownloadFile(FolderPathEnum path, string fileName)
        {
            var file = this.GetFolderPath(path) + @"\" + fileName;
            return File.ReadAllBytes(file);
        }

        public string GetMimeType(FolderPathEnum path, string fileName)
        {
            var file = this.GetFolderPath(path) + @"\" + fileName;
            string extension = Path.GetExtension(file).ToLowerInvariant();
            return extension switch
            {
                ".txt" => "text/plain",
                ".pdf" => "application/pdf",
                ".doc" => "application/vnd.ms-word",
                ".docx" => "application/vnd.ms-word",
                ".xls" => "application/vnd.ms-excel",
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".csv" => "text/csv",
                _ => ""
            };
        }

        public void SaveFile(FolderPathEnum path, byte[] document, string documentName)
        {
            File.WriteAllBytes(this.GetFolderPath(path) + @"\" + documentName, document);
        }

        private string GetFolderPath(FolderPathEnum path)
        {
            return path switch
            {
                FolderPathEnum.Expense => _configuration["MySettings:LocalAttachmentsPath"],
                FolderPathEnum.Map => _configuration["MySettings:GoogleMapPath"],
                _ => string.Empty
            };
        }
    }
}

