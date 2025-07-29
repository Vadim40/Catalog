using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ManagmentStoreService.Dto
{
    public class CreateImagesDto
    {
        public int VariantId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
