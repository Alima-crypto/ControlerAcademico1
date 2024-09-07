using Microsoft.EntityFrameworkCore;
using ControleAcademico1.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ControleAcademico1.Data
{
    public class ControleAcademico1Context : DbContext
    {
        public ControleAcademico1Context(DbContextOptions<ControleAcademico1Context> options)
            : base(options)
        {
        }

        public DbSet<Orientadores> Orientadores { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais, se necessário
        }
    }
}