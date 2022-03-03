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
   public class ConvertToWebpCommand:IRequest<IResult>
    {
        public IFormFile Image { get; set; }
        public class ConvertToWebpCommandHandler : IRequestHandler<ConvertToWebpCommand, IResult>
        {
            private readonly IImageService _imageService;

            public ConvertToWebpCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(ConvertToWebpCommand request, CancellationToken cancellationToken)
            {
                _imageService.ConvertToWebp(request.Image, ImageDirectoryOptions.Directory3);
                return new SuccessResult("Dönüştürüldü");
            }
        }
    }
}
