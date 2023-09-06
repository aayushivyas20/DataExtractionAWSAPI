using DataExtractionDto.Dto.AwsModel;
using DataExtractionInfra.ResponseWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionService.Srvc.ConfigparamsSrvc.Interface
{
    public interface IConfigParamsService
    {
        Task<Response<List<AwsFileInfo>>> GetByConfigParamsValName(string bucketName);
        Task<Response<bool>> DeleteAsync(string Key, string bucketName);
    }
}
