using Microsoft.EntityFrameworkCore.Migrations;

namespace HobbyHub.Migrations
{
    public partial class UserHobby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHobby_Hobbies_HobbyId",
                table: "UserHobby");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHobby_Users_UserId",
                table: "UserHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHobby",
                table: "UserHobby");

            migrationBuilder.RenameTable(
                name: "UserHobby",
                newName: "UserHobbies");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobby_UserId",
                table: "UserHobbies",
                newName: "IX_UserHobbies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobby_HobbyId",
                table: "UserHobbies",
                newName: "IX_UserHobbies_HobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHobbies",
                table: "UserHobbies",
                column: "UserHobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobbies_Hobbies_HobbyId",
                table: "UserHobbies",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobbies_Users_UserId",
                table: "UserHobbies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHobbies_Hobbies_HobbyId",
                table: "UserHobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHobbies_Users_UserId",
                table: "UserHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHobbies",
                table: "UserHobbies");

            migrationBuilder.RenameTable(
                name: "UserHobbies",
                newName: "UserHobby");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobbies_UserId",
                table: "UserHobby",
                newName: "IX_UserHobby_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobbies_HobbyId",
                table: "UserHobby",
                newName: "IX_UserHobby_HobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHobby",
                table: "UserHobby",
                column: "UserHobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobby_Hobbies_HobbyId",
                table: "UserHobby",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobby_Users_UserId",
                table: "UserHobby",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
