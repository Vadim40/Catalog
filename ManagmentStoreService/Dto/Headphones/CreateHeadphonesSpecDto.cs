namespace ManagmentStoreService.Dto.Headphones
{
    public class CreateHeadphonesSpecDto
    {
       public bool IsWireless { get; init; }
        public string FrequencyRangeHz { get; init; }
        public int CodecId { get; init; }
    }
}