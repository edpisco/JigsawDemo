using Microsoft.EntityFrameworkCore.Migrations;

namespace Jigsaw.MiniProject.Data.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeItems_TreeItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TreeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TreeItems",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "A", null });

            migrationBuilder.InsertData(
                table: "TreeItems",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 2, "B", 1 });

            migrationBuilder.InsertData(
                table: "TreeItems",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 4, "d", 1 });

            migrationBuilder.InsertData(
                table: "TreeItems",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 3, "C", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_TreeItems_ParentId",
                table: "TreeItems",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeItems");
        }
    }
}
