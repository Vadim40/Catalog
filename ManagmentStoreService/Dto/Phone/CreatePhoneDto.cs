using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto.Phone
{
    public class CreatePhoneDto
    {
        [Required]
        public string SerialNumber { get; set; }
        public int VariantId  { get; set; }
    }
}
