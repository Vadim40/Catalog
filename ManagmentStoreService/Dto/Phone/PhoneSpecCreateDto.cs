using System.ComponentModel.DataAnnotations;

namespace ManagmentStoreService.Dto.Phone
{
    public class PhoneSpecCreateDto
    {
       
        public int StorageGb { get; init; }

       
        public int RamGb { get; init; }
       
        public float DisplayIn { get; init; }
  
        public float CameraMp { get; init; }

    }
}
