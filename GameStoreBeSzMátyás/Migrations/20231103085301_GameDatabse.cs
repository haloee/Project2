using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStoreBeSzMátyás.Migrations
{
    /// <inheritdoc />
    public partial class GameDatabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uservideo_User_entity_User_EntitiesId",
                table: "uservideo");

            migrationBuilder.DropForeignKey(
                name: "FK_uservideo_VideoGame_entity_VideoGame_EntitiesId",
                table: "uservideo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoGame_entity",
                table: "VideoGame_entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_entity",
                table: "User_entity");

            migrationBuilder.RenameTable(
                name: "VideoGame_entity",
                newName: "VideoGame");

            migrationBuilder.RenameTable(
                name: "User_entity",
                newName: "User");

            migrationBuilder.AddColumn<int>(
                name: "VideoGameId",
                table: "uservideo",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoGame",
                table: "VideoGame",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_uservideo_UserId",
                table: "uservideo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_uservideo_VideoGameId",
                table: "uservideo",
                column: "VideoGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_uservideo_User_UserId",
                table: "uservideo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uservideo_User_User_EntitiesId",
                table: "uservideo",
                column: "User_EntitiesId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uservideo_VideoGame_VideoGameId",
                table: "uservideo",
                column: "VideoGameId",
                principalTable: "VideoGame",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_uservideo_VideoGame_VideoGame_EntitiesId",
                table: "uservideo",
                column: "VideoGame_EntitiesId",
                principalTable: "VideoGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_uservideo_User_UserId",
                table: "uservideo");

            migrationBuilder.DropForeignKey(
                name: "FK_uservideo_User_User_EntitiesId",
                table: "uservideo");

            migrationBuilder.DropForeignKey(
                name: "FK_uservideo_VideoGame_VideoGameId",
                table: "uservideo");

            migrationBuilder.DropForeignKey(
                name: "FK_uservideo_VideoGame_VideoGame_EntitiesId",
                table: "uservideo");

            migrationBuilder.DropIndex(
                name: "IX_uservideo_UserId",
                table: "uservideo");

            migrationBuilder.DropIndex(
                name: "IX_uservideo_VideoGameId",
                table: "uservideo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoGame",
                table: "VideoGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VideoGameId",
                table: "uservideo");

            migrationBuilder.RenameTable(
                name: "VideoGame",
                newName: "VideoGame_entity");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User_entity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoGame_entity",
                table: "VideoGame_entity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_entity",
                table: "User_entity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_uservideo_User_entity_User_EntitiesId",
                table: "uservideo",
                column: "User_EntitiesId",
                principalTable: "User_entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_uservideo_VideoGame_entity_VideoGame_EntitiesId",
                table: "uservideo",
                column: "VideoGame_EntitiesId",
                principalTable: "VideoGame_entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
