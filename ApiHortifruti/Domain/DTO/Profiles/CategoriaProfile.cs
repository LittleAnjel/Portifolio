namespace ApiHortifruti.Domain.DTO.Profiles;
using AutoMapper;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<PostCategoriaDTO, Categoria>().ReverseMap();
    }
}
