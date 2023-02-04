using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIdFromChildGiftOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildGiftOwnership",
                table: "ChildGiftOwnership");

            migrationBuilder.DropIndex(
                name: "IX_ChildGiftOwnership_ChildId",
                table: "ChildGiftOwnership");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ChildGiftOwnership");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildGiftOwnership",
                table: "ChildGiftOwnership",
                columns: new[] { "ChildId", "GiftId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildGiftOwnership",
                table: "ChildGiftOwnership");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ChildGiftOwnership",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildGiftOwnership",
                table: "ChildGiftOwnership",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChildGiftOwnership_ChildId",
                table: "ChildGiftOwnership",
                column: "ChildId");
        }
    }
}
