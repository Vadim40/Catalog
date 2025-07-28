using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreService.Models.PhoneEntities
{
    public class PhoneImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public PhoneModel Model { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public string PublicId { get; set; }

    }
}
