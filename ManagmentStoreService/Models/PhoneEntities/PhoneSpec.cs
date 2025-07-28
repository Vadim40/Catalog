using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreService.Models.PhoneEntities
{
    public class PhoneSpec
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public PhoneModel Model { get; set; }
        public int StorageGb { get; set; }
        public int RamGb { get; set; }
        public float DisplayIn { get; set; }
        public float CameraMp { get; set; }

    }

}
