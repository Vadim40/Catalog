using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Models.HeadphonesEntities
{
    public class HeadphonesModel
    {
        [Key]
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }

        public List<HeadphonesVariant> Variants { get; set; }
    }

}
