using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeverRecipeAPI.Models;

namespace SeverRecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineRecipesController : ControllerBase
    {
        private readonly MachineRecipeDataContext _context;

        public MachineRecipesController(MachineRecipeDataContext context)
        {
            _context = context;
        }

        // GET: api/MachineRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineRecipe>>> GetMachineRecipes()
        {
            return await _context.MachineRecipes.ToListAsync();
        }

        // GET: api/MachineRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineRecipe>> GetMachineRecipe(int id)
        {
            var machineRecipe = await _context.MachineRecipes.FindAsync(id);

            if (machineRecipe == null)
            {
                return NotFound();
            }

            return machineRecipe;
        }

        // PUT: api/MachineRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachineRecipe(int id, MachineRecipe machineRecipe)
        {
            if (id != machineRecipe.RecipeId)
            {
                return BadRequest();
            }

            _context.Entry(machineRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineRecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MachineRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MachineRecipe>> PostMachineRecipe(MachineRecipe machineRecipe)
        {
            _context.MachineRecipes.Add(machineRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachineRecipe", new { id = machineRecipe.RecipeId }, machineRecipe);
        }

        // DELETE: api/MachineRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachineRecipe(int id)
        {
            var machineRecipe = await _context.MachineRecipes.FindAsync(id);
            if (machineRecipe == null)
            {
                return NotFound();
            }

            _context.MachineRecipes.Remove(machineRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MachineRecipeExists(int id)
        {
            return _context.MachineRecipes.Any(e => e.RecipeId == id);
        }
    }
}
