using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto.Phone
{
    public class CreatePhoneModelDto
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
