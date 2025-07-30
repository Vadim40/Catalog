using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ManagmentStoreService.Models.HeadphonesEntities;

namespace ManagmentStoreService.Models.HeadphonesEntities
{
    public class HeadphonesImage
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }
        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        List<HeadphonesVariantImage> VariantImages { get; set; }

    }
}
