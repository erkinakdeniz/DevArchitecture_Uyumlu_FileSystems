using Core.Utilities.FileSystems;
using Core.Utilities.FileSystems.Options;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.File.Commands
{
   public class FolderUploadCommand:IRequest<IResult>
    {
        public IFormFile[] Folders { get; set; }
        public class FolderUploadCommandHandler : IRequestHandler<FolderUploadCommand, IResult>
        {
            private readonly IFileService _fileService;

            public FolderUploadCommandHandler(IFileService fileService)
            {
                _fileService = fileService;
            }
           
            public async Task<IResult> Handle(FolderUploadCommand request, CancellationToken cancellationToken)
            {
                _fileService.FolderUpload(request.Folders, FileDirectoryOptions.Directory1);
                return new SuccessResult("Dosya Upload Edildi.");
            }
        }
    }
}
