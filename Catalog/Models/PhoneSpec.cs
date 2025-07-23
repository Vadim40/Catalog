using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class PhoneSpec
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int StorageGb { get; set; }
        public int RamGb { get; set; }
        public float DisplayIn { get; set; }
        public string DisplayType { get; set; }
        public float CameraMp { get; set; }
    }

}
