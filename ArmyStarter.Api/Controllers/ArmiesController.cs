using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyStarter.Api.Models;

namespace ArmyStarter.Api.Controllers
{
    [Route("api/armies")]
    [ApiController]
    public class ArmiesController : ControllerBase
    {
        private readonly ArmyStarterContext _context;

        public ArmiesController(ArmyStarterContext context)
        {
            _context = context;
        }

        // GET: api/Armies
        [HttpGet]
        public async Task<IActionResult> GetArmies()
        {
            return Ok( _context.Army);
        }

        // GET: api/Armies/5
        [HttpGet("{idString}")]
        public async Task<IActionResult> GetArmy([FromRoute] string idString)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = new Guid(idString);

            Army selectedArmy = _context.Army.Include(e => e.ArmyUnits).ThenInclude(e => e.Options).FirstOrDefault(army => army.ArmyId == id);

            if (selectedArmy == null)
            {
                return NotFound();
            }

            return Ok(selectedArmy);
        }

        // PUT: api/Armies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmy([FromRoute] Guid id, [FromBody] Army army)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != army.ArmyId)
            {
                return BadRequest();
            }

            _context.Entry(army).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmyExists(id))
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

        // POST: api/Armies
        [HttpPost]
        public async Task<IActionResult> PostArmy([FromBody] Army army)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Army.Add(army);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArmy", new { id = army.ArmyId }, army);
        }

        // DELETE: api/Armies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArmy([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var army = await _context.Army.FindAsync(id);
            if (army == null)
            {
                return NotFound();
            }

            _context.Army.Remove(army);
            await _context.SaveChangesAsync();

            return Ok(army);
        }

        private bool ArmyExists(Guid id)
        {
            return _context.Army.Any(e => e.ArmyId == id);
        }
    }
}