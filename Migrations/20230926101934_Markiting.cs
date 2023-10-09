using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkitingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Markiting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisingcampaignss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisingcampaignss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Electioncampaignss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electioncampaignss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ourcustomers_Successess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ourcustomers_Successess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ourservicess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ourservicess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ourworkss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ourworkss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "whouss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_whouss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workteams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workteams", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisingcampaignss");

            migrationBuilder.DropTable(
                name: "Electioncampaignss");

            migrationBuilder.DropTable(
                name: "ourcustomers_Successess");

            migrationBuilder.DropTable(
                name: "Ourservicess");

            migrationBuilder.DropTable(
                name: "Ourworkss");

            migrationBuilder.DropTable(
                name: "whouss");

            migrationBuilder.DropTable(
                name: "workteams");
        }
    }
}
