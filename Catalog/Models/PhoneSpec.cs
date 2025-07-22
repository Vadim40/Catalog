namespace Catalog.Models
{
    public class PhoneSpec
    {
        public int Id { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int StorageGb { get; set; }
        public int RamGb { get; set; }
        public float DisplayIn { get; set; }
        public string DisplayType { get; set; }
        public float CameraMp { get; set; }
    }

}
