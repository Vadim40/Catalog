namespace ManagmentStoreService.Dto.Phone
{
    public class PhoneFilter
    {

        public List<int>? Manufacturers { get; init; }


        public string Color { get; init; }


        public int? MinStorageGb { get; init; }
        public int? MaxStorageGb { get; init; }

        public int? MinRamGb { get; init; }
        public int? MaxRamGb { get; init; }

        public float? MinDisplayIn { get; init; }
        public float? MaxDisplayIn { get; init; }

        public string DisplayType { get; init; }

        public float? MinCameraMp { get; init; }
        public float? MaxCameraMp { get; init; }

        public decimal? MinCost { get; init; }
        public decimal? MaxCost { get; init; }
    }

}
