using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto.Phone
{
    public class CreatePhoneDto
    {
        [Required]
        public string SerialNumber { get; init; }
        public int VariantId  { get; init; }
    }
}
