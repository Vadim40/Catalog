namespace Catalog.Models
{
    public class HeadphonesSpec
    {
        public int Id { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public bool IsWireless { get; set; }
        public string FrequencyRangeHz { get; set; }
        public string Codec { get; set; }
    }

}
