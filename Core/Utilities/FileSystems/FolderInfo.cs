using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileSystems
{
    public class FolderInfo
    {
        public string FolderName { get; set; }
        public string Direction { get; set; }
        public string FileName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastAccessTimeUTC { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastWriteTimeUTC { get; set; }
        public List<FolderInfo> Files { get; set; }
        public long Size { get; set; }
    }
}
