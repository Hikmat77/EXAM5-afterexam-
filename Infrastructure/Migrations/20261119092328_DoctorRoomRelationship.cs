using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DoctorRoomRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roomid",
                table: "doctors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_doctors_roomid",
                table: "doctors",
                column: "roomid");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_rooms_roomid",
                table: "doctors",
                column: "roomid",
                principalTable: "rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_rooms_roomid",
                table: "doctors");

            migrationBuilder.DropIndex(
                name: "IX_doctors_roomid",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "roomid",
                table: "doctors");
        }
    }
}
