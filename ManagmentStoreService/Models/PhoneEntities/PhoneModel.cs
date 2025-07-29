using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreService.Models.PhoneEntities
{
    public class PhoneModel
    {
        [Key]
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }
        public List<PhoneVariant> PhoneVariants { get; set; }
    }

}
