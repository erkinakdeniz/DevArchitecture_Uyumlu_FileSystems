using Core.Utilities.FileSystems;
using Core.Utilities.FileSystems.Options;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.File.Queries
{
  public  class GetFolderInfoQuery:IRequest<IDataResult<IEnumerable<FolderInfo>>>
    {
        public string Path { get; set; }
        public class GetFolderInfoQuerHandler : IRequestHandler<GetFolderInfoQuery, IDataResult<IEnumerable<FolderInfo>>>
        {
            private IFileService _fileService;

            public GetFolderInfoQuerHandler(IFileService fileService)
            {
                _fileService = fileService;
            }

            public async Task<IDataResult<IEnumerable<FolderInfo>>> Handle(GetFolderInfoQuery request, CancellationToken cancellationToken)
            {
                string myPath = FileDirectoryOptions.LocalDirectory + request.Path;
                var result= _fileService.GetFolderInfo(myPath);
                return new SuccessDataResult<IEnumerable<FolderInfo>>(result);
            }
        }
    }
}
