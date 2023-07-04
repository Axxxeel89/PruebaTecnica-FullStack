using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisteCredito_Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "reporteHorasExtras",
                newName: "estadoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRetiro",
                table: "Empleados",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reporteHorasExtras_estadoId",
                table: "reporteHorasExtras",
                column: "estadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_reporteHorasExtras_Estado_estadoId",
                table: "reporteHorasExtras",
                column: "estadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reporteHorasExtras_Estado_estadoId",
                table: "reporteHorasExtras");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_reporteHorasExtras_estadoId",
                table: "reporteHorasExtras");

            migrationBuilder.RenameColumn(
                name: "estadoId",
                table: "reporteHorasExtras",
                newName: "Estado");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRetiro",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
