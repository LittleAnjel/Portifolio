using System.ComponentModel.DataAnnotations;

namespace ApiDeTarefasMySql.Domain;

public class Tarefa
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Titulo { get; set; } = String.Empty;
    
    public bool Concluida { get; set; }
}