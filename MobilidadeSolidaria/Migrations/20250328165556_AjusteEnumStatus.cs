using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilidadeSolidaria.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEnumStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Equipamentos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Emprestimo");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Emprestimo");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Emprestimo");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Emprestimo");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "Emprestimo");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: "Emprestimo");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: "Emprestimo");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: "Doacao");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: "Doacao");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Status",
                value: "Doacao");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Status",
                value: "Doacao");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 12,
                column: "Status",
                value: "Doacao");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: "Doacao");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 14,
                column: "Status",
                value: "Doacao");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35284a4a-dce7-45c2-88c1-82c7f129a56e", "AQAAAAIAAYagAAAAEDFEsjWOXPn9pcb6jk+b+F1nj6yfnjrp6i2T7Gf3vaI6J0x1IKYHiMzh3jVdATDDrA==", "d2fe7413-6eb7-4b6d-abc5-e7e2237382ac" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 12,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipamentos",
                keyColumn: "Id",
                keyValue: 14,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ab87fa-46e0-4aa5-9751-d7fd0dd0ce43", "AQAAAAIAAYagAAAAEDiuJ+JnCNf2u2EgN7pjMdWc9eTVWcKx/DNnm8I+ZhZT7FIaJTf5df1hEQlpYITqag==", "e04cd54f-f0df-4c84-abcc-e0a9ca58e041" });
        }
    }
}
