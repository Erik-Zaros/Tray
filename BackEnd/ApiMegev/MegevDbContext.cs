﻿using megev.Models;
using Microsoft.EntityFrameworkCore;

namespace megev
{
    public partial class MegevDbContext : DbContext
    {
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<MetodoEntrega> MetodoEntrega { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }
        public DbSet<ObjetivoLoja> ObjetivoLoja { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public MegevDbContext(DbContextOptions<MegevDbContext> options)
            : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("TestDatabase") 
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                        .HasCharSet("utf8mb4");

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração adicional, se necessário
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
    