using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BornToMove.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RatingTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoveId",
                table: "MoveRating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "MoveRating",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Vote",
                table: "MoveRating",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_MoveRating_MoveId",
                table: "MoveRating",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveRating_Move_MoveId",
                table: "MoveRating",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoveRating_Move_MoveId",
                table: "MoveRating");

            migrationBuilder.DropIndex(
                name: "IX_MoveRating_MoveId",
                table: "MoveRating");

            migrationBuilder.DropColumn(
                name: "MoveId",
                table: "MoveRating");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "MoveRating");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "MoveRating");
        }
    }
}
