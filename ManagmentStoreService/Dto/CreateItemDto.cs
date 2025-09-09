using ManagmentStoreService.Models.Enums;

namespace ManagmentStoreService.Dto
{
    public class CreateItemDto
    {
        public string SerialNumber { get; init; }
        public CategoryType Category { get; init; }
    }
}
