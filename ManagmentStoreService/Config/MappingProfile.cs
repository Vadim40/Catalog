using AutoMapper;
using ManagmentStoreService.Dto;
using ManagmentStoreService.Dto.Phone;
using ManagmentStoreService.Models;
using ManagmentStoreService.Models.PhoneEntities;

namespace ManagmentStoreService.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<PhoneModel, PhoneModelDto>()
            .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.Name));

            CreateMap<PhoneSpec, PhoneSpecDto>();

            CreateMap<Manufacturer, IdNameDto>();
            
            CreateMap<Color, ColorDto>();
            CreateMap<PhoneImage, ImageDto>();
            CreateMap<PhoneVariantCreateDto, PhoneVariant>();
            CreateMap<PhoneSpecCreateDto, PhoneSpec>();
        }
    }
}
