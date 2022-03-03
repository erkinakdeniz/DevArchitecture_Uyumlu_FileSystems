using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileSystems
{
    public abstract class CommonService
    {

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                clear();
                File.Delete(filePath);
            }
        }
        public void DeleteFiles(string[] filePath)
        {
            clear();
            foreach (var deleteFilePath in filePath)
            {
                if (File.Exists(deleteFilePath))
                {

                    File.Delete(deleteFilePath);
                }
            }
        }
        public string FindDirectory(IFormFile file)
        {
            string[] filePathArray = file.FileName.Split("/");
            string fileDirectory = "";
            filePathArray[filePathArray.Length - 1] = "";
            foreach (var item in filePathArray)
            {
                if (item != "")
                    fileDirectory += item + @"\";
            }
            return fileDirectory;
        }
        public void Add(IFormFile file, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
            }
        }
        public async void AddAsync(IFormFile file, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(stream);
            }
        }

        private void clear()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
