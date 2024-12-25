using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoiffeurWebsite.Migrations
{
    /// <inheritdoc />
    public partial class TreatmentAddToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TreatmentID",
                table: "Appointments",
                column: "TreatmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Treatments_TreatmentID",
                table: "Appointments",
                column: "TreatmentID",
                principalTable: "Treatments",
                principalColumn: "TreatmentID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Treatments_TreatmentID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TreatmentID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TreatmentID",
                table: "Appointments");
        }
    }
}
