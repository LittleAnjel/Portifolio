namespace ApiHortifruti.Domain.DTO.Profiles;
using AutoMapper;

public class UnidadeMedidaProfile : Profile
{
    public UnidadeMedidaProfile()
    {
        CreateMap<PostUnidadeMedidaDTO, UnidadeMedida>().ReverseMap();
    }
}
