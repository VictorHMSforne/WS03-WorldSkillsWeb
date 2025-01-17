﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WS.Context;

#nullable disable

namespace WS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WS.Models.Pesquisa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("Pergunta1")
                        .HasColumnType("int");

                    b.Property<int>("Pergunta2")
                        .HasColumnType("int");

                    b.Property<int>("Pergunta3")
                        .HasColumnType("int");

                    b.Property<double>("Resultado")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Pesquisa");
                });
#pragma warning restore 612, 618
        }
    }
}
