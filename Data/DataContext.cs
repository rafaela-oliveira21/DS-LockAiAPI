using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using LockAiAPI.Models;
using System;

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
            modelBuilder.Entity<PlanoLocacao>().ToTable("TB_PLANO_LOCACAO");

            modelBuilder.Entity<PlanoLocacao>().HasData
            (
                new PlanoLocacao
                {
                    Id = 1,
                    Nome = "Armário 01",
                    IdUsuario = 101,
                    IdObjeto = 10,
                    IdPlanoLocacao = 1,
                    DataInicio = DateTime.Parse("2025-06-23"),
                    DataFim = DateTime.Parse("2025-06-29"),
                    DataValidade = DateTime.Parse("2025-06-29"),
                    Valor = (int)120f,
                    Situacao = "Ativo",
                    DataSituacao = DateTime.Parse("2025-06-28"),
                    IdUsuarioSituacao = 1
                },
                new PlanoLocacao
                {
                    Id = 2,
                    Nome = "Armário 02",
                    IdUsuario = 102,
                    IdObjeto = 11,
                    IdPlanoLocacao = 2,
                    DataInicio = DateTime.Parse("2025-06-24"),
                    DataFim = DateTime.Parse("2026-06-24"),
                    DataValidade = DateTime.Parse("2026-06-24"),
                    Valor = (int)120f,
                    Situacao = "Cancelado",
                    DataSituacao = DateTime.Parse("2025-06-29"),
                    IdUsuarioSituacao = 2
                },
                new PlanoLocacao
                {
                    Id = 3,
                    Nome = "Armário 03",
                    IdUsuario = 103,
                    IdObjeto = 12,
                    IdPlanoLocacao = 3,
                    DataInicio = DateTime.Parse("2025-07-01"),
                    DataFim = DateTime.Parse("2026-07-01"),
                    DataValidade = DateTime.Parse("2026-07-01"),
                    Valor = (int)120f,
                    Situacao = "Pago",
                    DataSituacao = DateTime.Parse("2025-06-30"),
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
