using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class Migration4_FixedParticipantsManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Reservations_ReservationId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ReservationId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Participants");

            migrationBuilder.CreateTable(
                name: "ParticipantReservation",
                columns: table => new
                {
                    ParticipantsCPRNumber = table.Column<long>(type: "bigint", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantReservation", x => new { x.ParticipantsCPRNumber, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ParticipantReservation_Participants_ParticipantsCPRNumber",
                        column: x => x.ParticipantsCPRNumber,
                        principalTable: "Participants",
                        principalColumn: "CPRNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantReservation_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantReservation_ReservationId",
                table: "ParticipantReservation",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantReservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ReservationId",
                table: "Participants",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Reservations_ReservationId",
                table: "Participants",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
