﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelacionamentoHeranca.Data;

#nullable disable

namespace RelacionamentoHeranca.Migrations
{
    [DbContext(typeof(EstoqueContext))]
    [Migration("20231128223952_perecivel")]
    partial class perecivel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RelacionamentoHeranca.Models.Produto", b =>
                {
                    b.Property<int?>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProdutoID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("ProdutoID");

                    b.ToTable("Produtos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Produto");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RelacionamentoHeranca.Models.Perecivel", b =>
                {
                    b.HasBaseType("RelacionamentoHeranca.Models.Produto");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sabor")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Perecivel");
                });
#pragma warning restore 612, 618
        }
    }
}
