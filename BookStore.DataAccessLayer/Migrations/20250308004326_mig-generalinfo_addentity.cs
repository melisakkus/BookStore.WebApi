using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class miggeneralinfo_addentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralInfos",
                columns: table => new
                {
                    GeneralInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUsContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMedia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralInfos", x => x.GeneralInfoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralInfos");
        }
    }
}
