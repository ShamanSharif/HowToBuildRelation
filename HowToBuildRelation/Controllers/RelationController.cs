using HowToBuildRelation.Data;
using HowToBuildRelation.Dto;
using HowToBuildRelation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HowToBuildRelation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RelationController : ControllerBase
{
    private readonly DataContext _context;

    public RelationController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto characterCreateDto)
    {
        var newCharacter = new Character
        {
            Name = characterCreateDto.Name
        };

        var newBackpack = new Backpack
        {
            Description = characterCreateDto.Backpack.Description,
            Character = newCharacter
        };

        var weapons = characterCreateDto.Weapons.Select(
                w => new Weapon
                {
                    Name = w.Name, 
                    Character = newCharacter
                })
            .ToList();

        var factions = characterCreateDto.Factions.Select(
                f => new Faction
                {
                    Name = f.Name,
                    Characters = new List<Character> { newCharacter }
                })
            .ToList();

        newCharacter.Backpack = newBackpack;
        newCharacter.Weapons = weapons;
        newCharacter.Factions = factions;

        _context.Characters.Add(newCharacter);
        await _context.SaveChangesAsync();

        return Ok(await _context.Characters
                .Include(c=> c.Backpack)
                .Include(c => c.Weapons)
                .Include(c => c.Factions)
            .ToListAsync());
    }
}