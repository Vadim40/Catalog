using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class Headphones
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public HeadphonesModel Model { get; set; }
        [ForeignKey("HeadphoneSpec")]
        public int HeadphonesSpecId { get; set; }
        public HeadphonesSpec HeadphonesSpec { get; set; }
    }

}
