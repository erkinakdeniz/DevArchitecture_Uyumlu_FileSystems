using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Image.Commands
{
   public class DeleteImagesCommand:IRequest<IResult>
    {
        public string[] Path { get; set; }
        public class DeleteImagesCommandHandler : IRequestHandler<DeleteImagesCommand, IResult>
        {
            private readonly IImageService _imageService;

            public DeleteImagesCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(DeleteImagesCommand request, CancellationToken cancellationToken)
            {
                _imageService.DeleteImages(request.Path);
                return new SuccessResult("Silindi");
            }
        }
    }
}
