using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string SerialNumber { get; set; }

        [ForeignKey("CategoryType")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public ItemStatus Status { get; set; }
        [ForeignKey("Location")]
        public int? LocationId { get; set; }
        public Location Location { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }

}
