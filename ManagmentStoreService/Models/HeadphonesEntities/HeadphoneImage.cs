using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreService.Models.HeadphonesEntities
{
    public class HeadphonesImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public HeadphonesModel Model { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public int PublicId { get; set; }

    }
}
