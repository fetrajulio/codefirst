// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using entityCodeFirst.Data;

namespace entityCodeFirst.Migrations.AmieDb
{
    [DbContext(typeof(AmieDbContext))]
    [Migration("20220527163209_AddAmie")]
    partial class AddAmie
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("entityCodeFirst.Models.Amie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdP1")
                        .HasColumnType("int");

                    b.Property<int>("IdP2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Amis");
                });
#pragma warning restore 612, 618
        }
    }
}
