using Amazon.S3;
using DataExtractionDto.Dto.AwsModel;
using DataExtractionInfra.ResponseWrapper;
using DataExtractionRepository.Repo.ConfigParamsRepo.Interface;
using DataExtractionService.Srvc.ConfigparamsSrvc.Interface;

namespace DataExtractionService.Srvc.ConfigparamsSrvc.Impl
{
    public class ConfigParamsService : IConfigParamsService
    {
        private readonly IConfigParamsRepository _configParamsRepository;

        public ConfigParamsService(IConfigParamsRepository configParamsRepository)
        {
            _configParamsRepository = configParamsRepository;
        }

        public async Task<Response<List<AwsFileInfo>>> GetByConfigParamsValName(string bucketName)
        {
            // "AWS_RECYCLE_BUCKET_NAME"
            var awsBucketName = await _configParamsRepository.GetByConfigParamsValName(bucketName);
            if (awsBucketName == null || awsBucketName.Count == 0) throw new Exception("AWS Bucket Not Found");

            var AWSAccessKey = await _configParamsRepository.GetByConfigParamsValName("AWS_ACCESS_KEY");
            if (AWSAccessKey == null || AWSAccessKey.Count == 0) throw new Exception("AWS ACCESS KEY Not Found");

            var AWSSecretKey = await _configParamsRepository.GetByConfigParamsValName("AWS_ACCESS_SECRET_KEY");
            if (AWSAccessKey == null || AWSAccessKey.Count == 0) throw new Exception("AWS ACCESS SECRET KEY Not Found");

            var client = new AmazonS3Client(AWSAccessKey?.FirstOrDefault()?.configParamVal, AWSSecretKey?.FirstOrDefault()?.configParamVal, Amazon.RegionEndpoint.APSouth1);
            if (client == null ) throw new Exception("AWS Client Not Connect");

            var bucket_Name = awsBucketName.FirstOrDefault()?.configParamVal;
            if(string.IsNullOrWhiteSpace(bucket_Name)) throw new Exception("Bucket Name Is Empty");

            var S3Objects = client.ListObjectsAsync(bucket_Name).Result?.S3Objects;
            if (S3Objects == null || S3Objects.Count == 0) throw new Exception(" Bucket Is Empty!, No Data Found");

            List<AwsFileInfo> AwsFileInfos = new List<AwsFileInfo>(); 

            foreach (var item in S3Objects)
            {
                AwsFileInfos.Add( new AwsFileInfo 
                {
                    Url = new Uri("https://"+ bucket_Name + ".s3."+ Amazon.RegionEndpoint.APSouth1.OriginalSystemName + ".amazonaws.com/" + item.Key),
                    Name = item.Key,
                    CreatedOn = item.LastModified,
                });
            }

            return new Response<List<AwsFileInfo>>(AwsFileInfos);
        }

        public async Task<Response<bool>> DeleteAsync(string Key, string bucketName)
        {
            var awsBucketName = await _configParamsRepository.GetByConfigParamsValName(bucketName);
            if (awsBucketName == null || awsBucketName.Count == 0) throw new Exception("AWS Bucket Not Found");

            var AWSAccessKey = await _configParamsRepository.GetByConfigParamsValName("AWS_ACCESS_KEY");
            if (AWSAccessKey == null || AWSAccessKey.Count == 0) throw new Exception("AWS ACCESS KEY Not Found");

            var AWSSecretKey = await _configParamsRepository.GetByConfigParamsValName("AWS_ACCESS_SECRET_KEY");
            if (AWSAccessKey == null || AWSAccessKey.Count == 0) throw new Exception("AWS ACCESS SECRET KEY Not Found");

            var client = new AmazonS3Client(AWSAccessKey?.FirstOrDefault()?.configParamVal, AWSSecretKey?.FirstOrDefault()?.configParamVal, Amazon.RegionEndpoint.APSouth1);
            if (client == null) throw new Exception("AWS Client Not Connect");

            var bucket_Name = awsBucketName.FirstOrDefault()?.configParamVal;
            if (string.IsNullOrWhiteSpace(bucket_Name)) throw new Exception("Bucket Name Is Empty");
            try
            {
                var S3Objects = client.DeleteObjectAsync(bucket_Name, Key).Result;
                if (S3Objects == null) throw new Exception(" Bucket Is Empty!, No Data Found");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return new Response<bool>(true);
        }
    }
}
