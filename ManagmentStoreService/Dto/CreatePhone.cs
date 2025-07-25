using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto
{
    public class CreatePhone
    {
        [Required]
        public string UniqueId { get; set; } // TODO подумать как лучше это сделать
    }
}
