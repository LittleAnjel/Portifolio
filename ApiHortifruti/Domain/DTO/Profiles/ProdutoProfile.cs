namespace ApiHortifruti.Domain.DTO.Profiles;
using AutoMapper;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<PostProdutoDTO, Produto>().ReverseMap();
    }
}
