namespace Levi9.Cinema.Api.Services
{
    public interface IAwsS3Service
    {
        Task<string> PutImageToS3(string key, string content);
    }
}