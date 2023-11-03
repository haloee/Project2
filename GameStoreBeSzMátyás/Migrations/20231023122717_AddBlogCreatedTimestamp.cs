using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStoreBeSzMátyás.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_entity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGame_entity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGame_entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "uservideo",
                columns: table => new
                {
                    User_EntitiesId = table.Column<int>(type: "int", nullable: false),
                    VideoGame_EntitiesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uservideo", x => new { x.User_EntitiesId, x.VideoGame_EntitiesId });
                    table.ForeignKey(
                        name: "FK_uservideo_User_entity_User_EntitiesId",
                        column: x => x.User_EntitiesId,
                        principalTable: "User_entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uservideo_VideoGame_entity_VideoGame_EntitiesId",
                        column: x => x.VideoGame_EntitiesId,
                        principalTable: "VideoGame_entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_uservideo_VideoGame_EntitiesId",
                table: "uservideo",
                column: "VideoGame_EntitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "uservideo");

            migrationBuilder.DropTable(
                name: "User_entity");

            migrationBuilder.DropTable(
                name: "VideoGame_entity");
        }
    }
}
