using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileSystems.Extension
{
    public static class FileSystemMiddlewareExtensions
    {
        public static IApplicationBuilder UseFile(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<FileSystemMiddleware>();
        }
    }
}
