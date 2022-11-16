using ControleDeDocumentos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeDocumentos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<DocumentoModel> Documentos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentoModel>(x =>
            {
                x.ToTable("Documentos");
                x.HasKey(y => y.Id);
                x.HasIndex(y => y.Codigo).IsUnique();
                x.Property(y => y.Titulo).IsRequired();
                x.Property(y => y.Processo).IsRequired();
                x.Property(y => y.Categoria).IsRequired();
                x.Property(y => y.Arquivo).IsRequired();
            });
        }
    }


}
