using AutoMapper;
using ElectronicStore.BackEnd.Entities;
using ElectronicStore.BackEnd.Models.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Entity -> DTO
        CreateMap<Items, ItemDto>()
            .ForMember(dest => dest.ItemTypeName,
                       opt => opt.MapFrom(src => src.ItemTypes.ToString()));

        // Request -> Entity
        CreateMap<CreateItemRequest, Items>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IsDelete, opt => opt.Ignore());
    }
}
