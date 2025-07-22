namespace Catalog.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int? PhoneSpecId { get; set; }
        public PhoneSpec PhoneSpec { get; set; }

        public int? ModelId { get; set; }
        public PhoneModel Model { get; set; }
    }

}
