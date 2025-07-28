using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ManagmentStoreService.Dto
{
    public class CreateImagesDto
    {
        public int ModelId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
