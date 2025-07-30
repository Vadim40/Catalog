using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
