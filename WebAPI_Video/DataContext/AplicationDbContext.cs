using Microsoft.EntityFrameworkCore;
using WebAPI_Video.Models;

namespace WebAPI_Video.DataContext
{
    public class AplicationDbContext : DbContext // aqui está sendo feita uma herança com o DbContext do Entityframework que foi instalado
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) // por padrão é assim que é criado esse construtor de conexão com o bancod de dados
        {

        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; } //Essa linha de codigo cria a tabela no banco, no caso aqui é a FuncionarioModel com os atributos que lá está

    }
}
