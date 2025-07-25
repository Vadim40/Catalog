using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreService.Models
{
    public class HeadphonesSpec
    {
        [Key]
        public int Id { get; set; }
        public bool IsWireless { get; set; }
        public string FrequencyRangeHz { get; set; }
        [ForeignKey("Codec")]
        public int CodecId { get; set; }
        public CodecType Codec { get; set; }
    }

}
