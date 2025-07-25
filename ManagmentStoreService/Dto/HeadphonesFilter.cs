namespace StoreService.Dto
{
    public class HeadphonesFilter
    {
        public List<int>? Manufacturers { get; set; }
        public decimal? MinCost { get; set; }
        public decimal? MaxCost { get; set; }
        public bool? IsWireless { get; set; }
        public List<int>? Codecs { get; set; }
    }
}
