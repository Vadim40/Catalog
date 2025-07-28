namespace ManagmentStoreService.Services
{
    public interface ICloudinaryService
    {
        public Task<(string Url, string PublicId)> UploadImageAsync(IFormFile file);
    }
}
