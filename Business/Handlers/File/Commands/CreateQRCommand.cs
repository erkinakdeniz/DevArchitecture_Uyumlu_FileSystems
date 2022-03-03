using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.File.Commands
{
   public class CreateQRCommand:IRequest<IDataResult<Byte[]>>
    {
        public string Context { get; set; }
        public class CreateQRCommandHandler : IRequestHandler<CreateQRCommand, IDataResult<Byte[]>>
        {
            private readonly IFileService _ifileService;

            public CreateQRCommandHandler(IFileService ifileService)
            {
                _ifileService = ifileService;
            }

            public async Task<IDataResult<Byte[]>> Handle(CreateQRCommand request, CancellationToken cancellationToken)
            {
               var result= _ifileService.CreateQR(request.Context);
                //"data:image/png;base64,"
                return new SuccessDataResult<Byte[]>(result);

            }
        }
    }
}
