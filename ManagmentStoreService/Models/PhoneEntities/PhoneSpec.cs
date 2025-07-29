using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace StoreService.Models.PhoneEntities
{
    [Index(nameof(StorageGb), nameof(RamGb), nameof(DisplayIn), nameof(CameraMp), IsUnique = true, Name = "IX_UniquePhoneSpec")]

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
