using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HowToBuildRelation.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Faction_FactionsId",
                table: "CharacterFaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapon_Characters_CharacterId",
                table: "Weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faction",
                table: "Faction");

            migrationBuilder.RenameTable(
                name: "Weapon",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "Faction",
                newName: "Factions");

            migrationBuilder.RenameIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapons",
                newName: "IX_Weapons_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factions",
                table: "Factions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Factions_FactionsId",
                table: "CharacterFaction",
                column: "FactionsId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Factions_FactionsId",
                table: "CharacterFaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factions",
                table: "Factions");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "Weapon");

            migrationBuilder.RenameTable(
                name: "Factions",
                newName: "Faction");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapon",
                newName: "IX_Weapon_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faction",
                table: "Faction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Faction_FactionsId",
                table: "CharacterFaction",
                column: "FactionsId",
                principalTable: "Faction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapon_Characters_CharacterId",
                table: "Weapon",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
