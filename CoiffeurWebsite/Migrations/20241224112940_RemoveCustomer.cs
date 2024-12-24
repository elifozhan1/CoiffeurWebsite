using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoiffeurWebsite.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_CustomerID",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CustomerID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_userId",
                table: "Appointments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_userId",
                table: "Appointments",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_userId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_userId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerID",
                table: "Appointments",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_CustomerID",
                table: "Appointments",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
