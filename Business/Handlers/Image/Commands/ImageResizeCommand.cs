using Core.Utilities.FileSystems;
using Core.Utilities.FileSystems.Options;
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
   public class ImageResizeCommand:IRequest<IResult>
    {
        public IFormFile Image { get; set; }
        public class ImageResizeCommandHandler : IRequestHandler<ImageResizeCommand, IResult>
        {
            private readonly IImageService _imageService;

            public ImageResizeCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(ImageResizeCommand request, CancellationToken cancellationToken)
            {
                _imageService.ImageResize(request.Image, ImageDirectoryOptions.Directory1, ImageOptions.Width,ImageOptions.Height,ImageOptions.PredecessorName);
                return new SuccessResult("eklendi");
            }
        }
    }
}
