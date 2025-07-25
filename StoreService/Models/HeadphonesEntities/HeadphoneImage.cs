using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreService.Models.HeadphonesEntities
{
    public class HeadphonesImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("HeadphonesModel")]
        public int HeadphonesModelId { get; set; }
        public HeadphonesModel HeadphonesModel { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public int PublicId { get; set; }

    }
}
