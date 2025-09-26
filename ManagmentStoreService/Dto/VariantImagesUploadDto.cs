using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto
{
    public class VariantImagesUploadDto
    {
        
        public int VariantId { get; init; }
        
        public List<IFormFile> Images { get; init; }
    }
}
