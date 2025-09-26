     
namespace ManagmentStoreService.Dto.Phone
{
    public class PhoneVariantDto
    {
        public int Id { get; init; }
        public int ModelId { get; init; }
        public int ColorId { get; init; }
        
        public string Name { get; init; }
        
        
        public List<ImageDto> Images { get; set; }
        public List<PhoneSpecDto> Specs { get; set; }
        public decimal Cost { get; init; }
    }
}
