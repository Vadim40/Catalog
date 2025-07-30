
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Models.HeadphonesEntities
{
    public class HeadphonesSpec
    {
        [Key]
        public int Id { get; set; }

        public bool IsWireless { get; set; }
        public string FrequencyRangeHz { get; set; }
        public int CodecId { get; set; }
        public CodecType Codec { get; set; }
    }

}
