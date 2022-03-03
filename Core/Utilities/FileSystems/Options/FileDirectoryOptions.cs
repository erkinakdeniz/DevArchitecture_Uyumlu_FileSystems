using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileSystems.Options
{
    public static class FileDirectoryOptions
    {
        public static string LocalDirectory => Environment.CurrentDirectory + @"\wwwroot\";
        public static string Directory1 => $@"{LocalDirectory}test1\test2\test3\";

    }
}
