using Business.Handlers.Image.Commands;
using Business.Handlers.UserClaims.Queries;
using Core.Entities.Concrete;
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
    public class ImageController : BaseApiController
    {
        /// <summary>
        /// Add Image
        /// </summary>
        /// <remarks>Görselinizi Sunucuya Ekler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("addimage")]
        public async Task<IActionResult> AddImage([FromForm] AddImageCommand addImageCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(addImageCommand));
        }

        /// <summary>
        /// Add Image Asynchronous
        /// </summary>
        /// <remarks>Görselinizi Sunucuya Ekler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("addimageasync")]
        public async Task<IActionResult> AddImageAsync([FromForm] AddImageAsyncCommand addImageAsyncCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(addImageAsyncCommand));
        }

        /// <summary>
        /// Add Images
        /// </summary>
        /// <remarks>Görsellerinizi Sunucuya Ekler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("addimages")]
        public async Task<IActionResult> AddImages([FromForm] AddImagesCommand addImagesCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(addImagesCommand));
        }

        /// <summary>
        /// Add Images Asynchronous
        /// </summary>
        /// <remarks>Görsellerinizi Sunucuya Ekler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>

        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("addimagesasync")]
        public async Task<IActionResult> AddImagesAsync([FromForm] AddImagesAsyncCommand addImagesAsyncCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(addImagesAsyncCommand));
        }



        /// <summary>
        /// Delete Image
        /// </summary>
        /// <remarks>Görselinizi Sunucudan Siler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("deleteimage")]
        public async Task<IActionResult> DeleteImage([FromForm] DeleteImageCommand deleteImageCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteImageCommand));
        }




        /// <summary>
        /// Delete Images
        /// </summary>
        /// <remarks>Görsellerinizi Sunucudan Siler</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("deleteimages")]
        public async Task<IActionResult> DeleteImages([FromBody] DeleteImagesCommand deleteImagesCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteImagesCommand));
        }



        /// <summary>
        /// Update Image
        /// </summary>
        /// <remarks>Sunucuda ki Görselinizi Günceller</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut("updateimage")]
        public async Task<IActionResult> UpdateImage([FromBody] UpdateImageCommand updateImageCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateImageCommand));
        }



        /// <summary>
        /// Update Images Asynchronous
        /// </summary>
        /// <remarks>Sunucuda ki Görselinizi Günceller</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut("updateimagesasync")]
        public async Task<IActionResult> UpdateImagesAsync([FromBody] UpdateImagesAsyncCommand updateImagesAsyncCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateImagesAsyncCommand));
        }

        /// <summary>
        /// Convert to Webp
        /// </summary>
        /// <remarks>Görseli webp formatına dönüştür</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("converttowebp")]
        public async Task<IActionResult> ConvertToWebp([FromForm] ConvertToWebpCommand ConvertToWebpCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(ConvertToWebpCommand));
        }

        /// <summary>
        /// Image Resize
        /// </summary>
        /// <remarks>Görselin boyutunu ayarlar</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("imageresize")]
        public async Task<IActionResult> ImageResize([FromForm] ImageResizeCommand imageResizeCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(imageResizeCommand));
        }

        /// <summary>
        /// ImageConvertToBase64
        /// </summary>
        /// <remarks>Görseli Base64 Formatına Çevirir</remarks>
        /// <return>test2</return>
        /// <response code="200"></response>
        [AllowAnonymous]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("imageconverttobase64")]
        public async Task<IActionResult> ImageConvertToBase64([FromForm] ImageConvertToBase64Command imageConvertToBase64Command)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(imageConvertToBase64Command));
        }


    }
}
