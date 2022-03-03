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
   public class AddImagesAsyncCommand:IRequest<IResult>
    {
        public IFormFile[] Images { get; set; }

        public class AddImagesAsyncCommandHandler : IRequestHandler<AddImagesAsyncCommand, IResult>
        {
            private readonly IImageService _imageService;

            public AddImagesAsyncCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }
            public async Task<IResult> Handle(AddImagesAsyncCommand request, CancellationToken cancellationToken)
            {
               await _imageService.AddImagesAsync(request.Images, ImageDirectoryOptions.Directory2);
                return new SuccessResult("eklendi");
            }
        }
    }
}
