using Microsoft.AspNetCore.Http;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileSystems
{
    public class FileManager : CommonService, IFileService
    {
        List<FolderInfo> _folderInfos;

        public FileManager()
        {
            _folderInfos = new List<FolderInfo>();
        }

        public Byte[] CreateQR(string content)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return stream.ToArray();
            }
        }

        public void FolderUpload(IFormFile[] files, string directory, bool isOverWrite = false)
        {
            if (files.Length <= 0 || files == null)
                throw new NullReferenceException();

            foreach (var myFile in files)
            {

                string folderPath = this.FindDirectory(myFile);
                string folderDirectory = directory + folderPath;
                string folder = folderDirectory + myFile.FileName;
                if (File.Exists(folder) && !isOverWrite)
                {
                    continue;
                }
                if (Directory.Exists(folderDirectory))
                {
                    this.Add(myFile, folder);
                }
                else
                {
                    Directory.CreateDirectory(folderDirectory);
                    this.Add(myFile, folder);
                }
            }
        }

        public Task FolderUploadAsync(IFormFile[] files, string directory, bool isOverWrite = false)
        {
            return Task.Run(() =>
            {
                if (files.Length <= 0 || files == null)
                    throw new NullReferenceException();

                foreach (var myFile in files)
                {

                    string folderPath = this.FindDirectory(myFile);
                    string folderDirectory = directory + folderPath;
                    string folder = folderDirectory + myFile.FileName;
                    if (File.Exists(folder) && !isOverWrite)
                    {
                        continue;
                    }
                    if (Directory.Exists(folderDirectory))
                    {
                        this.AddAsync(myFile, folder);
                    }
                    else
                    {
                        Directory.CreateDirectory(folderDirectory);
                        this.AddAsync(myFile, folder);
                    }
                }
            });

        }

        public IEnumerable<FolderInfo> GetFolderInfo(string path)
        {

            string[] subdirectoryEntries = Directory.GetDirectories(path);

            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo fi = new DirectoryInfo(subdirectory);
                FolderInfo folderInfo = new FolderInfo()
                {
                    FolderName = fi.Name,
                    Direction = fi.FullName,
                    CreationTime = fi.CreationTime,
                    LastAccessTime = fi.LastAccessTime,
                    LastAccessTimeUTC = fi.LastAccessTimeUtc,
                    LastWriteTime = fi.LastWriteTime,
                    LastWriteTimeUTC = fi.LastWriteTimeUtc,
                    Files = GetFilesInfo(subdirectory)
                };
                _folderInfos.Add(folderInfo);
                GetFolderInfo(subdirectory);

            }

            return _folderInfos;
        }
        private List<FolderInfo> GetFilesInfo(string dir)
        {
            List<FolderInfo> filesinfo = new List<FolderInfo>();
            string[] Files = Directory.GetFiles(dir, "*.*");
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                FolderInfo foi = new FolderInfo()
                {
                    FileName = fi.Name,
                    Direction = fi.FullName,
                    LastAccessTime = fi.LastAccessTime,
                    LastAccessTimeUTC = fi.LastAccessTimeUtc,
                    LastWriteTime = fi.LastWriteTime,
                    LastWriteTimeUTC = fi.LastWriteTimeUtc,
                    Size = fi.Length,
                    CreationTime = fi.CreationTime
                };
                filesinfo.Add(foi);
            }
            return filesinfo;
        }
    }
}
