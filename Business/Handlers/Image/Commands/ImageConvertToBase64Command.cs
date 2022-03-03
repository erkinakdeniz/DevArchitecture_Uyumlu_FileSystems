using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Image.Commands
{
   public class ImageConvertToBase64Command:IRequest<IResult>
    {
        public IFormFile Image { get; set; }
        public class ImageConvertToBase64CommandHandler : IRequestHandler<ImageConvertToBase64Command, IResult>
        {
            private readonly IImageService _imageService;

            public ImageConvertToBase64CommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(ImageConvertToBase64Command request, CancellationToken cancellationToken)
            {
                return new SuccessResult(_imageService.ImageConvertToBase64(request.Image));
            }
        }
    }
}
