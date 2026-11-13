using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perigeo.Api.Migrations;

/// <inheritdoc />
public partial class _20261113094029_Inicial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Contactos",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Nombre = table.Column<string>(type: "TEXT", nullable: false),
                Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                Telefono = table.Column<string>(type: "TEXT", nullable: false),
                Email = table.Column<string>(type: "TEXT", nullable: true),
                Empresa = table.Column<string>(type: "TEXT", nullable: true),
                Cumpleanos = table.Column<DateOnly>(type: "TEXT", nullable: true),
                Notas = table.Column<string>(type: "TEXT", nullable: true),
                EsFavorito = table.Column<bool>(type: "INTEGER", nullable: false),
                FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                Color = table.Column<string>(type: "TEXT", nullable: false),
                Orbita = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Contactos", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Contactos");
    }
}
