namespace ApiHortifruti.Domain.DTO.Profiles;

using ApiHortifruti.Domain;
using ApiHortifruti.Domain.DTO.ItemEntrada;

using AutoMapper;

public class ItemEntradaProfile : Profile
{
    public ItemEntradaProfile()
    {
        CreateMap<ItemEntradaDTO, ItemEntrada>().ReverseMap();
    }
}
