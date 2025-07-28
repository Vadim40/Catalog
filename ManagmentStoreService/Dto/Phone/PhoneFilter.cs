namespace ManagmentStoreService.Dto.Phone
{
    public class PhoneFilter
    {

        public List<int>? Manufacturers { get; set; }


        public string Color { get; set; }


        public int? MinStorageGb { get; set; }
        public int? MaxStorageGb { get; set; }

        public int? MinRamGb { get; set; }
        public int? MaxRamGb { get; set; }

        public float? MinDisplayIn { get; set; }
        public float? MaxDisplayIn { get; set; }

        public string DisplayType { get; set; }

        public float? MinCameraMp { get; set; }
        public float? MaxCameraMp { get; set; }

        public decimal? MinCost { get; set; }
        public decimal? MaxCost { get; set; }
    }

}
