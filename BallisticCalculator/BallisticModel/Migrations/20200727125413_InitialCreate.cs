using Microsoft.EntityFrameworkCore.Migrations;

namespace BallisticModel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ammunition",
                columns: table => new
                {
                    AmmunitionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmmunitionName = table.Column<string>(nullable: true),
                    Coefficient = table.Column<float>(nullable: false),
                    Grain = table.Column<float>(nullable: false),
                    Diameter = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammunition", x => x.AmmunitionID);
                });

            migrationBuilder.CreateTable(
                name: "FirearmTypes",
                columns: table => new
                {
                    FirearmTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirearmTypes", x => x.FirearmTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Firearms",
                columns: table => new
                {
                    FirearmID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirearmTypeID = table.Column<int>(nullable: false),
                    AmmunitionID = table.Column<int>(nullable: false),
                    FirearmName = table.Column<string>(nullable: true),
                    MuzzleVelocity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firearms", x => x.FirearmID);
                    table.ForeignKey(
                        name: "FK_Firearms_Ammunition_AmmunitionID",
                        column: x => x.AmmunitionID,
                        principalTable: "Ammunition",
                        principalColumn: "AmmunitionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firearms_FirearmTypes_FirearmTypeID",
                        column: x => x.FirearmTypeID,
                        principalTable: "FirearmTypes",
                        principalColumn: "FirearmTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firearms_AmmunitionID",
                table: "Firearms",
                column: "AmmunitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Firearms_FirearmTypeID",
                table: "Firearms",
                column: "FirearmTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firearms");

            migrationBuilder.DropTable(
                name: "Ammunition");

            migrationBuilder.DropTable(
                name: "FirearmTypes");
        }
    }
}
