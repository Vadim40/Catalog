using ManagmentStoreService.Models.PhoneEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Models.PhoneEntities
{
    public class PhoneVariant
    {
        [Key]
        public int Id { get; set; }

        public int ModelId { get; set; }
        public PhoneModel Model { get; set; }
        public int SpecId { get; set; }
        public PhoneSpec Spec { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public decimal Cost { get; set; }

        public List<PhoneVariantImage> VariantImages { get; set; }

    }
}
