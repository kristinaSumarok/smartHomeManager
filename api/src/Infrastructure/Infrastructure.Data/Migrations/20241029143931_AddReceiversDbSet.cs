using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homemap.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReceiversDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Receiver_ReceiverId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Receiver_Projects_ProjectId",
                table: "Receiver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receiver",
                table: "Receiver");

            migrationBuilder.RenameTable(
                name: "Receiver",
                newName: "Receivers");

            migrationBuilder.RenameIndex(
                name: "IX_Receiver_ProjectId",
                table: "Receivers",
                newName: "IX_Receivers_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receivers",
                table: "Receivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Receivers_ReceiverId",
                table: "Device",
                column: "ReceiverId",
                principalTable: "Receivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_Projects_ProjectId",
                table: "Receivers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Receivers_ReceiverId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivers_Projects_ProjectId",
                table: "Receivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receivers",
                table: "Receivers");

            migrationBuilder.RenameTable(
                name: "Receivers",
                newName: "Receiver");

            migrationBuilder.RenameIndex(
                name: "IX_Receivers_ProjectId",
                table: "Receiver",
                newName: "IX_Receiver_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receiver",
                table: "Receiver",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Receiver_ReceiverId",
                table: "Device",
                column: "ReceiverId",
                principalTable: "Receiver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receiver_Projects_ProjectId",
                table: "Receiver",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
