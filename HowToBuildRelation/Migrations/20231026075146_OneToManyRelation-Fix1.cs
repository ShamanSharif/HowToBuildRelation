using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HowToBuildRelation.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelationFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChracterId",
                table: "Weapon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChracterId",
                table: "Weapon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
