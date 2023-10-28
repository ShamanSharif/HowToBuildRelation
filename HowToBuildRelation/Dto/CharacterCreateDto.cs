namespace HowToBuildRelation.Dto;

public class CharacterCreateDto
{
    public string Name { get; set; }
    public BackpackCreateDto Backpack { get; set; }
    public List<WeaponCreateDto> Weapons { get; set; }
    public List<FactionCreateDto> Factions { get; set; }
}