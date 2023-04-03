using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application._Common.Interfaces
{

    public interface IFileService
    {
        void SaveFile(FolderPathEnum path, byte[] document, string documentName);

        void UploadFile(FolderPathEnum path, string file, string fileName);

        string GetMimeType(FolderPathEnum path, string fileName);

        byte[] DownloadFile(FolderPathEnum path, string fileName);
    }
}
