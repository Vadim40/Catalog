using ManagmentStoreService.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Dto
{
    public class ItemDto
    {
        public int Id { get; init; }
      
        public string SerialNumber { get; init; }

       
        public int CategoryId { get; init; }
        
        public int? StatusId { get; init; }
        
        public int? LocationId { get; init; }
       
       
    }
}
