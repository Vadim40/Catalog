using ManagmentStoreService.Models.Enums;

namespace ManagmentStoreService.Dto
{
    public class CreateItemDto
    {
        public string SerialNumber { get; set; }
        public CategoryType Category { get; set; }
    }
}
