// <auto-generated />
using ControleDeDocumentos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleDeDocumentos.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("ControleDeDocumentos.Models.DocumentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Arquivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Processo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Documentos");
                });
#pragma warning restore 612, 618
        }
    }
}
