using ManagmentStoreService.Models.HeadphonesEntities;

namespace ManagmentStoreService.Models.HeadphonesEntities
{
    public class HeadphonesVariant
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public HeadphonesModel Model { get; set; }
        public int SpecId { get; set; }
        public HeadphonesSpec Spec { get; set; }
        public decimal Cost { get; set; }
        public string Color { get; set; }

        public List<HeadphonesVariantImage> VariantImages { get; set; }
    }
}
