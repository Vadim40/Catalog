using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto
{
    public class CreatePhoneModelDto
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
