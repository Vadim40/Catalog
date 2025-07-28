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
        public int? SpecId { get; set; }
        public PhoneSpec Spec { get; set; }
        [ForeignKey("Model")]
        public int? ModelId { get; set; }
        public PhoneModel Model { get; set; }
        [ForeignKey("Price")]
        public int PriceId { get; set; }
        public PhonePrice Price { get; set; }
    }

}
