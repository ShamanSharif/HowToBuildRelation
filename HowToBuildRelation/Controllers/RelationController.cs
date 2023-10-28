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

        newCharacter.Backpack = newBackpack;

        _context.Characters.Add(newCharacter);
        await _context.SaveChangesAsync();

        return Ok(await _context.Characters.Include(c=> c.Backpack).ToListAsync());
    }
}