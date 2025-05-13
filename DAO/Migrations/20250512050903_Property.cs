using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
