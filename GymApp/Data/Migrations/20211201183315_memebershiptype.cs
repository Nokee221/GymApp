using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class memebershiptype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Memberships");

            migrationBuilder.AddColumn<string>(
                name: "MembershipTypeId",
                table: "Memberships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId1",
                table: "Memberships",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    MembershipTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.MembershipTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MembershipTypeId1",
                table: "Memberships",
                column: "MembershipTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_MembershipTypes_MembershipTypeId1",
                table: "Memberships",
                column: "MembershipTypeId1",
                principalTable: "MembershipTypes",
                principalColumn: "MembershipTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_MembershipTypes_MembershipTypeId1",
                table: "Memberships");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_MembershipTypeId1",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId1",
                table: "Memberships");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Memberships",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
