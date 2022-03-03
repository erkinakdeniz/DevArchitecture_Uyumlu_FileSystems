using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileSystems
{
    public interface IFileService
    {
        void FolderUpload(IFormFile[] files, string directory, bool isOverWrite = false);
        Task FolderUploadAsync(IFormFile[] files, string directory, bool isOverWrite = false);
        IEnumerable<FolderInfo> GetFolderInfo(string path);
        Byte[] CreateQR(string content);
    }
}
