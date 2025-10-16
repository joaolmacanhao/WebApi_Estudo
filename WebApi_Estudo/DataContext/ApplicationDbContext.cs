using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.Models;

namespace WebApi_Estudo.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) //esse tipo de construtor é obrigatório para o Entity Framework conectar com o banco de dados
        {
                
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; } //representa a tabela no banco de dados
    }
}
    