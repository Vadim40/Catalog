using StoreService.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentStoreService.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
      
        public string SerialNumber { get; set; }

       
        public int CategoryId { get; set; }
        
        public int? StatusId { get; set; }
        
        public int? LocationId { get; set; }
       
       
    }
}
