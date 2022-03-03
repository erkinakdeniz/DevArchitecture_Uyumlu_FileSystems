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
    
    public class AddImagesCommand:IRequest<IResult>
    {
        public IFormFile[] Images { get; set; }
        
        public class AddImagesCommandHandler : IRequestHandler<AddImagesCommand, IResult>
        {
            private readonly IImageService _imageService;

            public AddImagesCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(AddImagesCommand request, CancellationToken cancellationToken)
            {
                _imageService.AddImages(request.Images, ImageDirectoryOptions.Directory3);
                return new SuccessResult("eklendi");
            }
        }
    }
}
