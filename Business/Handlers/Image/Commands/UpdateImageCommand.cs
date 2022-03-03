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
   public class UpdateImageCommand:IRequest<IResult>
    {
        public IFormFile Image { get; set; }
        public class UpdateImageCommandHandler:IRequestHandler<UpdateImageCommand, IResult>
        {
            private readonly IImageService _imageservice;


            public UpdateImageCommandHandler(IImageService imageservice)
            {
                _imageservice = imageservice;
            }

            public async Task<IResult> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
            {
              
                _imageservice.UpdateImage(request.Image, ImageDirectoryOptions.Directory2);
                return new SuccessResult("Eklendi");
            }
        }
    }
}
