namespace ManagmentStoreService.Dto.Headphones
{
    public class CreateHeadphonesSpecDto
    {
       public bool IsWireless { get; set; }
        public string FrequencyRangeHz { get; set; }
        public int CodecId { get; set; }
    }
}