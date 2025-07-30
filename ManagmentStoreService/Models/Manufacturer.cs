using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
