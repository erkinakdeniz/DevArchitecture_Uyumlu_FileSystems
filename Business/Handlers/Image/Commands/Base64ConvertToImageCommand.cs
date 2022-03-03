using Core.Utilities.FileSystems;
using Core.Utilities.FileSystems.Options;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Image.Commands
{
   public class Base64ConvertToImageCommand:IRequest<IResult>
    {
        public string Base64Code { get; set; }
        public class Base64ConvertToImageHandler : IRequestHandler<Base64ConvertToImageCommand, IResult>
        {
            private readonly IImageService _imageService;

            public Base64ConvertToImageHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(Base64ConvertToImageCommand request, CancellationToken cancellationToken)
            {
                _imageService.Base64ConvertToImage(request.Base64Code, ImageDirectoryOptions.Directory4);
                return new SuccessResult("Eklendi");
            }
        }
    }
}
