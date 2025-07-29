using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreService.Models.PhoneEntities
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
    

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [ForeignKey("Spec")]
       
        public int VariantId { get; set; }
        public PhoneVariant Variant { get; set; }
    }

}
