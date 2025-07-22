namespace Catalog.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? StatusId { get; set; }
        public ItemStatus Status { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }
    }

}
