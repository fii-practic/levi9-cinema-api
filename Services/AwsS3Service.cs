using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;

namespace Levi9.Cinema.Api.Services
{
    public class AwsS3Service : IAwsS3Service
    {
        private readonly IAmazonS3 s3Client;
        private readonly AwsS3Options awsS3Options;

        public AwsS3Service(IAmazonS3 s3Client, IOptions<AwsS3Options> awsS3Options)
        {
            this.s3Client = s3Client;
            this.awsS3Options = awsS3Options.Value;
        }

        public async Task<string> PutImageToS3(string key, string encodedString)
        {
            var data = Convert.FromBase64String(encodedString);
            var stream = new MemoryStream(data);

            var request = new PutObjectRequest
            {
                BucketName = awsS3Options.Name,
                Key = key,
                ContentType = "image/png",
                InputStream = stream
            };

            await s3Client.PutObjectAsync(request);

            return $"https://{awsS3Options.Name}.s3.{awsS3Options.Region}.amazonaws.com/{key}";
        }
    }
}