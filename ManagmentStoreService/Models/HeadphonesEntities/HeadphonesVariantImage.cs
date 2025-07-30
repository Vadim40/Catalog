using ManagmentStoreService.Models.HeadphonesEntities;

namespace ManagmentStoreService.Models.HeadphonesEntities
{
    
    public class HeadphonesVariantImage
    {
        public int VariantId { get; set; }
        public HeadphonesVariant Variant { get; set; }
        public int ImageId { get; set; }
        public HeadphonesImage Image { get; set; }
       
    }
}
