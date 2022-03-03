using Business.Handlers.Image.ValidationRules;
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
    public class AddImageAsyncCommand : IRequest<IResult>
    {
        public IFormFile Image { get; set; }
        public class AddImageAsyncCommandHandler : IRequestHandler<AddImageAsyncCommand, IResult>
        {
            private readonly IImageService _imageService;

            public AddImageAsyncCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }
            [ValidationAspect(typeof(AddImageAsyncCommandValidatior), Priority = 1)]
            public async Task<IResult> Handle(AddImageAsyncCommand request, CancellationToken cancellationToken)
            {
               await _imageService.AddImageAsync(request.Image, ImageDirectoryOptions.Directory1);
                return new SuccessResult("Eklendi");
            }
        }
    }
}
