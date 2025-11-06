using System.Text.Json.Serialization;
using ApiHortifruti.Domain.Enum;

namespace ApiHortifruti.Domain;

public partial class MotivoMovimentacao
{
    public int Id { get; set; }

    public TipoMovimentacaoEnum TipoMovimentacao { get; set; }

    public bool Ativo { get; set; }

    [JsonIgnore]
    public virtual ICollection<Entrada> Entrada { get; set; } = new List<Entrada>();

    [JsonIgnore]
    public virtual ICollection<Saida> Saida { get; set; } = new List<Saida>();
}
