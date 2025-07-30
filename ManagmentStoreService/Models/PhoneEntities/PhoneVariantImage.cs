using static System.Net.Mime.MediaTypeNames;
using ManagmentStoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Models.PhoneEntities
{
    public class PhoneVariantImage
    {
        public int VariantId { get; set; }
        public PhoneVariant Variant { get; set; }

        public int ImageId { get; set; }
        public PhoneImage Image { get; set; }
    }
}
