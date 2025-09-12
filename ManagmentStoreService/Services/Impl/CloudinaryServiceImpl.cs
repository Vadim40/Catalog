
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ManagmentStoreService.Services.Impl
{
    public class CloudinaryServiceImpl : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly string _cloudName;
        private readonly string _apiKey;
        private readonly string _apiSecret;
        public CloudinaryServiceImpl()
        {
            _cloudName = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME");
            _apiKey = Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY");
            _apiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET");

            if (string.IsNullOrEmpty(_cloudName) ||
          string.IsNullOrEmpty(_apiKey) ||
          string.IsNullOrEmpty(_apiSecret))
            {
                throw new Exception("Cloudinary credentials are not set in the environment.");
            }
            var account = new Account(_cloudName, _apiKey, _apiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public async Task<(string Url, string PublicId)> UploadImageAsync(IFormFile file)
        {
           
                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = Path.GetFileNameWithoutExtension(file.FileName),
                    Overwrite = true
                };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return (uploadResult.SecureUrl.ToString(), uploadResult.PublicId);
            
        }
    }
}
