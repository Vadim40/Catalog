using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Models.HeadphonesEntities
{
    public class Headphones
    {
        [Key]
        public int Id { get; set; }

        
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int VariantId { get; set; }
        public HeadphonesVariant Variant { get; set; }
    }

}
