using ApiHortifruti.Domain.DTO.ItemSaida;

public partial class PostSaidaDTO
{

    public int MotivoMovimentacaoId { get; set; }



    public int FuncionarioId { get; set; }



    public string? CadastroCliente { get; set; }



    public decimal ValorTotal { get; set; }



    public bool Desconto { get; set; }



    public decimal? ValorDesconto { get; set; }



    public decimal ValorFinal { get; set; }



    public DateOnly DataSaida { get; set; }



    public TimeOnly HoraSaida { get; set; }


    
    public List<ItemSaidaDTO> ItemSaida { get; set; } = new List<ItemSaidaDTO>();
}