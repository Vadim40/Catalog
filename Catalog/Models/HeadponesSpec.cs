using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class HeadphonesSpec
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public bool IsWireless { get; set; }
        public string FrequencyRangeHz { get; set; }
        public string Codec { get; set; }
    }

}
