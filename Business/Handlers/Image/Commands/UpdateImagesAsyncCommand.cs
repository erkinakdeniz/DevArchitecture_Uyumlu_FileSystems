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
   public class UpdateImagesAsyncCommand:IRequest<IResult>
    {
        public IFormFile[] Images { get; set; }
        public class UpdateImagesAsyncCommandHandler : IRequestHandler<UpdateImagesAsyncCommand, IResult>
        {
            private readonly IImageService _imageService;

            public UpdateImagesAsyncCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(UpdateImagesAsyncCommand request, CancellationToken cancellationToken)
            {
                var update= _imageService.UpdateImagesAsync(request.Images, ImageDirectoryOptions.Directory3);
                return new SuccessResult("Güncellendi");
            }
        }
    }
}
