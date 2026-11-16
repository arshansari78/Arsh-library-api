using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstBackend.Api.Migrations
{
    /// <inheritdoc />
    public partial class gkjkjfgiygukulh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentPhone",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Arsh",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "838d0917-e47a-4db9-8fdb-79f15beffb7e", "AQAAAAIAAYagAAAAEKKQX1CCHW1cuZ72SYwuoP1PwWzHZbs4osMRnhdQYk7LTii1DIjNUc3fL4UJI7WZtg==", "c52e5bfb-d367-4462-b93f-5239e23e03be" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ParentPhone",
                table: "Students",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Arsh",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c7a8438-a717-4abb-a5b8-c52ecb75c8f5", "AQAAAAIAAYagAAAAEPWAKNzKJJnTK1BgmNtx7q/g1h4c0msgr0bD7zBcDwoFL0dZawPa4ia6v0bXebc6CA==", "d6c64192-d2cd-44fb-a9a8-84e416b811d0" });
        }
    }
}
