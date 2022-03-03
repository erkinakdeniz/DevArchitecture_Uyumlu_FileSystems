using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileSystems.Options
{
   public static class ImageDirectoryOptions
    {
        private static string LocalDirectory => Environment.CurrentDirectory + @"\wwwroot\";
        public static string Directory1 => $@"{LocalDirectory}test1\test2\test3\";
        public static string Directory2 => $@"{LocalDirectory}test4\test5\test6\";
        public static string Directory3 => $@"{LocalDirectory}test1\test2\test5\";
        public static string Directory4 => $@"{LocalDirectory}test2\test4\test6\";

    }
}
