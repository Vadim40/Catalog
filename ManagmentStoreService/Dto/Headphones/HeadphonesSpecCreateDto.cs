namespace ManagmentStoreService.Dto.Headphones
{
    public class HeadphonesSpecCreateDto
    {
       public bool IsWireless { get; init; }
        public string FrequencyRangeHz { get; init; }
        public int CodecId { get; init; }
    }
}