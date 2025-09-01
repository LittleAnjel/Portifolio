using Microsoft.EntityFrameworkCore; 
using ApiDeTarefasMySql.Domain; 
 
namespace ApiDeTarefasMySql.Data; 
 
public class AppDbContext : DbContext
{ 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
 
    public DbSet<Tarefa> Tarefas { get; set; } 
}