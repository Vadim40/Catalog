using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class PhoneImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PhoneModel")]
        public  int PhoneModelId { get; set; }
        public PhoneModel PhoneModel { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public int PublicId { get; set; }

    }
}
