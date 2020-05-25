using Microsoft.EntityFrameworkCore.Migrations;

namespace STODataBaseImplement.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(nullable: true),
                    PartPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkParts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workId = table.Column<int>(nullable: false),
                    PartId = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    partPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkParts_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkParts_Work_workId",
                        column: x => x.workId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkParts_PartId",
                table: "WorkParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkParts_workId",
                table: "WorkParts",
                column: "workId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkParts");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Work");
        }
    }
}
