using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileSystems.Extension
{
    public class FileSystemMiddleware
    {
        RequestDelegate _next;
        public FileSystemMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = null;
            await _next.Invoke(httpContext);
        }
    }
}
