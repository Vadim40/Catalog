using AutoMapper;
using ManagmentStoreService.Dto.Phone;
using StoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<PhoneModel, PhoneModelDto>();
            CreateMap<PhoneSpec, PhoneSpecDto>();
        }
    }
}
