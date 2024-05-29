using AutoMapper;
using backendP.DTOs;
using backendP.Models;

namespace backendP.Automappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap < ItemInsertDto, Item>();
            CreateMap<Item, ItemDto>();
            //ANOTACION DE CAUNDO SON DIFERENTES CAMPOS 
            //CreateMap<Item, ItemDto>().ForMember(dto=>dto.Id,m=>m.MapFrom(b=b.ItemID));
            CreateMap<ItemUpdateDto,Item>();
        }
    }
}
