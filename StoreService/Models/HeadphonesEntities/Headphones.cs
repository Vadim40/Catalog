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

        [ForeignKey("Spec")]
        public int SpecId { get; set; }
        public HeadphonesSpec Spec { get; set; }

        [ForeignKey("Price")]
        public int PriceId { get; set; }
        public HeadphonesPrice Price { get; set; }
    }

}
