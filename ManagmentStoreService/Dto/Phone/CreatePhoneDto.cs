using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto.Phone
{
    public class CreatePhoneDto
    {
        [Required]
        public string SerialNumber { get; set; }
        public int ModelId { get; set; }
        public int SpecId { get; set; }
    }
}
