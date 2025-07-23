using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [ForeignKey("PhoneSpec")]
        public int? PhoneSpecId { get; set; }
        public PhoneSpec PhoneSpec { get; set; }
        [ForeignKey("Model")]
        public int? ModelId { get; set; }
        public PhoneModel Model { get; set; }
    }

}
