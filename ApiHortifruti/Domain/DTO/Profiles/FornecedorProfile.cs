namespace ApiHortifruti.Domain.DTO.Profiles;
using AutoMapper;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        CreateMap<PostFornecedorDTO, Fornecedor>().ReverseMap();
    }
}
