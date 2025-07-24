using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models
{
    public class PhoneSpec
    {
        [Key]
        public int Id { get; set; }
        public int StorageGb { get; set; }
        public int RamGb { get; set; }
        public float DisplayIn { get; set; }
        public float CameraMp { get; set; }

    }

}
