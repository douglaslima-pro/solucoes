using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemBacklogs_Sprints_SprintId",
                table: "ItemBacklogs");

            migrationBuilder.DropIndex(
                name: "IX_ItemBacklogs_SprintId",
                table: "ItemBacklogs");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "ItemBacklogs");

            migrationBuilder.CreateTable(
                name: "SprintBacklogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SprintId = table.Column<int>(type: "int", nullable: false),
                    ItemBacklogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintBacklogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SprintBacklogs_ItemBacklogs_ItemBacklogId",
                        column: x => x.ItemBacklogId,
                        principalTable: "ItemBacklogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SprintBacklogs_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SprintBacklogs_ItemBacklogId",
                table: "SprintBacklogs",
                column: "ItemBacklogId");

            migrationBuilder.CreateIndex(
                name: "IX_SprintBacklogs_SprintId",
                table: "SprintBacklogs",
                column: "SprintId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SprintBacklogs");

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "ItemBacklogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemBacklogs_SprintId",
                table: "ItemBacklogs",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBacklogs_Sprints_SprintId",
                table: "ItemBacklogs",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id");
        }
    }
}
