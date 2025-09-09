namespace ManagmentStoreService.Dto.Headphones
{
    public class HeadphonesFilter
    {
        public List<int>? Manufacturers { get; init; }
        public decimal? MinCost { get; init; }
        public decimal? MaxCost { get; init; }
        public bool? IsWireless { get; init; }
        public List<int>? Codecs { get; init; }
    }
}
