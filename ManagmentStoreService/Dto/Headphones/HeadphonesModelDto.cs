using StoreService.Models;

namespace ManagmentStoreService.Dto.Headphones
{
    public class HeadphonesModelDto
    {
        public int Id { get; set; }
        public int ManufacturerId {  get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
