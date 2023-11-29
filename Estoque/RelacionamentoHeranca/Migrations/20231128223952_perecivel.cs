using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelacionamentoHeranca.Migrations
{
    /// <inheritdoc />
    public partial class perecivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataValidade",
                table: "Produtos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Peso",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sabor",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataValidade",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Sabor",
                table: "Produtos");
        }
    }
}
