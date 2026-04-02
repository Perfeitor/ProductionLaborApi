using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionLaborApi.Migrations
{
    /// <inheritdoc />
    public partial class addPositionIdToWorklogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionId",
                table: "WorkLog",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "WorkLog");
        }
    }
}
