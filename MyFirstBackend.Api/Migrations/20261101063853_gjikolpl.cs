using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstBackend.Api.Migrations
{
    /// <inheritdoc />
    public partial class gjikolpl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Arsh",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f2de2e9-15f3-489f-827a-e09c0c328414", "AQAAAAIAAYagAAAAEJLMPZfdqA66ym1CdsJbeN1hqgyq9nUyNlu32aHh6ECtBFUuqVkrpLJgGrpgyvw6qA==", "682ec94d-59df-4541-850b-081e7e21bb74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Arsh",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "838d0917-e47a-4db9-8fdb-79f15beffb7e", "AQAAAAIAAYagAAAAEKKQX1CCHW1cuZ72SYwuoP1PwWzHZbs4osMRnhdQYk7LTii1DIjNUc3fL4UJI7WZtg==", "c52e5bfb-d367-4462-b93f-5239e23e03be" });
        }
    }
}
