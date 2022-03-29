using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FKInTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketEntities_ShowEntities_ShowId",
                table: "TicketEntities");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "TicketEntities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEntities_ShowEntities_ShowId",
                table: "TicketEntities",
                column: "ShowId",
                principalTable: "ShowEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketEntities_ShowEntities_ShowId",
                table: "TicketEntities");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "TicketEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketEntities_ShowEntities_ShowId",
                table: "TicketEntities",
                column: "ShowId",
                principalTable: "ShowEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
