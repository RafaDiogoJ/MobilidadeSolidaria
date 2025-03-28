using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilidadeSolidaria.Migrations
{
    /// <inheritdoc />
    public partial class CriarUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c8d5a45-0cb8-474b-a1b8-588828a840e3", "AQAAAAIAAYagAAAAEAnDAK0G4SUMXcOhpqe5Rjsl0nkE7/eFJXtBIchqnT+7isfCgbdDid6BYm8eCTk2LQ==", "4b0fa609-7afa-4026-8c61-cba85da694b4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35284a4a-dce7-45c2-88c1-82c7f129a56e", "AQAAAAIAAYagAAAAEDFEsjWOXPn9pcb6jk+b+F1nj6yfnjrp6i2T7Gf3vaI6J0x1IKYHiMzh3jVdATDDrA==", "d2fe7413-6eb7-4b6d-abc5-e7e2237382ac" });
        }
    }
}
