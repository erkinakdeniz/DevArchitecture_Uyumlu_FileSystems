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

namespace Business.Handlers.File.Commands
{
  public  class FolderUploadAsyncCommand:IRequest<IResult>
    {
        public IFormFile[] Folders { get; set; }
        public class FolderUploadAsyncCommandHandler : IRequestHandler<FolderUploadAsyncCommand, IResult>
        {
            private readonly IFileService _ifileService;

            public FolderUploadAsyncCommandHandler(IFileService ifileService)
            {
                _ifileService = ifileService;
            }

            public async Task<IResult> Handle(FolderUploadAsyncCommand request, CancellationToken cancellationToken)
            {
               await _ifileService.FolderUploadAsync(request.Folders, FileDirectoryOptions.Directory1);
                return new SuccessResult("Dosya Uplad Edildi.");
            }
        }
    }
}
