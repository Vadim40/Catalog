using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto
{
    public class CreatePhoneSpecDto
    {
        [Required]
        public int StorageGb { get; set; }

        [Required] 
        public int RamGb { get; set; }
        [Required]
        public float DisplayIn { get; set; }
        [Required]
        public float CameraMp { get; set; }

    }
}
