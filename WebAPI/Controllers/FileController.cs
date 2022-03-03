using Business.Handlers.File.Commands;
using Business.Handlers.File.Queries;
using Business.Handlers.Image.Commands;
using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseApiController
    {
        /// <summary>
        /// Upload Folder
        /// </summary>
        /// <remarks>Görselinizi Sunucuya Ekler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("uploadfolder")]
        [RequestFormLimits(MultipartBodyLengthLimit = 27262976)]
        [RequestSizeLimit(27262976)]
        public async Task<IActionResult> UploadFolder([FromForm] FolderUploadCommand folderUploadCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(folderUploadCommand));
        }
        /// <summary>
        /// Upload Folder Async
        /// </summary>
        /// <remarks>Görselinizi Sunucuya Ekler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("uploadfolderasync")]
        [RequestFormLimits(MultipartBodyLengthLimit = 27262976)]
        [RequestSizeLimit(27262976)]
        public async Task<IActionResult> UploadFolderAsync([FromForm] FolderUploadAsyncCommand folderUploadAsyncCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(folderUploadAsyncCommand));
        }

        /// <summary>
        /// Get Folder Info
        /// </summary>
        /// <remarks>Dizinde ki klasör ve dosya bilgilerini getirir.</remarks>
        /// <return>FolderInfo</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FolderInfo>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getfolderinfo")]
        public async Task<IActionResult> GetFolderInfo()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetFolderInfoQuery()));
        }

        /// <summary>
        /// Get Folder Info
        /// </summary>
        /// <remarks>Dizinde ki klasör ve dosya bilgilerini getirir.</remarks>
        /// <return>FolderInfo</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("createqr")]
        public async Task<IActionResult> CreateQR([FromForm] CreateQRCommand createQRCommand)
        {
            return GetResponseOnlyResultData(await Mediator.Send(createQRCommand));
        }
    }
}
