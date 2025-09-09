using ManagmentStoreService.Models;

namespace ManagmentStoreService.Dto.Headphones
{
    public class HeadphonesModelDto
    {
        public int Id { get; init; }
        public int ManufacturerId {  get; init; }
        public string Name { get; init; }
        public string Color { get; init; }
    }
}
