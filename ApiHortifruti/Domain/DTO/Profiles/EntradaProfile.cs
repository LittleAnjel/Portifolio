namespace ApiHortifruti.Domain.DTO.Profiles;
using AutoMapper;

public class EntradaProfile : Profile
{
    public EntradaProfile()
    {
        CreateMap<PostEntradaDTO, Entrada>().ReverseMap();
    }
}
