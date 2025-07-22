namespace Catalog.Models
{
    public class Headphones
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ModelId { get; set; }
        public HeadphonesModel Model { get; set; }

        public int HeadphonesSpecId { get; set; }
        public HeadphonesSpec HeadphonesSpec { get; set; }
    }

}
