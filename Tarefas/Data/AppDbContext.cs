using Microsoft.EntityFrameworkCore;
using Tarefas.Models;

namespace Tarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().HasData(
                new Tarefa { Id = 1, Desc = "Compilar o código", Terminado = true },
                new Tarefa { Id = 2, Desc = "Corrigir bug",      Terminado = false }
            );
        }
    }
}
