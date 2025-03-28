using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilidadeSolidaria.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEquipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ab87fa-46e0-4aa5-9751-d7fd0dd0ce43", "AQAAAAIAAYagAAAAEDiuJ+JnCNf2u2EgN7pjMdWc9eTVWcKx/DNnm8I+ZhZT7FIaJTf5df1hEQlpYITqag==", "e04cd54f-f0df-4c84-abcc-e0a9ca58e041" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3787faf6-cc8f-45ac-a073-296457220964", "AQAAAAIAAYagAAAAEB7Gv4DXsmZF7q4h2p28Zu5LiYbLu4mFmkirFpDFgiYaDohyWYpXTwGYm6NIwsNAxw==", "748efc0a-909b-44eb-8878-014214788a41" });
        }
    }
}
