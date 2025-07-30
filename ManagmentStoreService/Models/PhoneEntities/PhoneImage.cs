using ManagmentStoreService.Models.PhoneEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Models.PhoneEntities
{
    public class PhoneImage
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public string PublicId { get; set; }
        public List<PhoneVariantImage> VariantImages { get; set; }

    }
}
