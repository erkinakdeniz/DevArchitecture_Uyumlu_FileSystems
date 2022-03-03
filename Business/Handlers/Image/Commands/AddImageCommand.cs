using Core.Aspects.Autofac.Validation;
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
using static Business.Handlers.Image.ValidationRules.ImageValidatior;

namespace Business.Handlers.Image.Commands
{
   public class AddImageCommand:IRequest<IResult>
    {
        public IFormFile Image { get; set; }
        public class AddImageCommandHandler : IRequestHandler<AddImageCommand, IResult>
        {
            private readonly IImageService _imageService;
            public AddImageCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }
            [ValidationAspect(typeof(AddImageCommandValidatior), Priority = 1)]
            public async Task<IResult> Handle(AddImageCommand request, CancellationToken cancellationToken)
            {
                _imageService.AddImage(request.Image,ImageDirectoryOptions.Directory1,true);
                return new SuccessResult("Eklendi");
            }
        }
    }
}
