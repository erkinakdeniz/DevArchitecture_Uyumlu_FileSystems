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
   public class DeleteImageCommand:IRequest<IResult>
    {
        public string Path { get; set; }
        public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, IResult>
        {
            private readonly IImageService _imageService;

            public DeleteImageCommandHandler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<IResult> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
            {
                _imageService.DeleteImage(request.Path);
                return new SuccessResult("Silindi");
            }
        }
    }
}
