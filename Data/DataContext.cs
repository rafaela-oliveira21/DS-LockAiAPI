using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using LockAiAPI.Models;

namespace LockAiAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<PlanoLocacao> PlanoLocacao { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlanoLocacao>().HasData
            (      
                new PlanoLocacao
                {
                    Id = 1,
                    Data = "2025-06-25",
                    IdUsuario = 101,
                    IdObjeto = 10,
                    IdPlanoLocacao = 1,
                    DataInicio = "2025-06-23",
                    DataFim = "2025-06-29",
                    DataValidade = "2025-06-29",
                    Valor = 120f,
                    Situacao = 'L',
                    DataSituacao = "2025-06-28", 
                    IdUsuarioSituacao = 1
                },
                new PlanoLocacao
                {
                    Id = 2,
                    Data = "2025-06-26",
                    IdUsuario = 102,
                    IdObjeto = 11,
                    IdPlanoLocacao = 2,
                    DataInicio = "2025-06-24",
                    DataFim = "2025-06-30",
                    DataValidade = "2025-06-30",
                    Valor = 150f,
                    Situacao = 'A',
                    DataSituacao = "2025-06-29",
                    IdUsuarioSituacao = 2
                },
                new PlanoLocacao
                {
                    Id = 3,
                    Data = "2025-06-27",
                    IdUsuario = 103,
                    IdObjeto = 12,
                    IdPlanoLocacao = 3,
                    DataInicio = "2025-06-25",
                    DataFim = "2025-07-01",
                    DataValidade = "2025-07-01",
                    Valor = 200f,
                    Situacao = 'C',
                    DataSituacao = "2025-06-30",
                    IdUsuarioSituacao = 3
                }
            );
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}
