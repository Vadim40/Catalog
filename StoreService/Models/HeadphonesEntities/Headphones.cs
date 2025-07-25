using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreService.Models.HeadphonesEntities
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

        [ForeignKey("HeadphonesPrice")]
        public int HeadphonesPriceId { get; set; }
        public HeadphonesPrice HeadphonesPrice { get; set; }
    }

}
