using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_MembershipTypes_MembershipTypeId1",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_MembershipTypeId1",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId1",
                table: "Memberships");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipTypeId",
                table: "Memberships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MembershipTypeId",
                table: "Memberships",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_MembershipTypes_MembershipTypeId",
                table: "Memberships",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "MembershipTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_MembershipTypes_MembershipTypeId",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_MembershipTypeId",
                table: "Memberships");

            migrationBuilder.AlterColumn<string>(
                name: "MembershipTypeId",
                table: "Memberships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId1",
                table: "Memberships",
                type: "int",
                nullable: true);

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
    }
}
