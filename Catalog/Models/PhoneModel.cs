namespace Catalog.Models
{
    public class PhoneModel
    {
        public int Id { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }
    }

}
