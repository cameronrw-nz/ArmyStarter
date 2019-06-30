using ArmyStarter.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Api.Controllers
{
    [Route("api/armyUnits")]
    [ApiController]
    public class ArmyUnitsController : ControllerBase
    {
        private readonly ArmyStarterContext _context;

        public ArmyUnitsController(ArmyStarterContext context)
        {
            _context = context;
        }

        // GET: api/armyUnits
        [HttpGet]
        public async Task<IActionResult> GetArmyUnits()
        {
            return Ok(_context.Armies);
        }

        // GET: api/armyUnits/5
        [HttpGet("{idString}")]
        public async Task<IActionResult> GetArmyUnit([FromRoute] string idString)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = new Guid(idString);

            ArmyUnit selectedArmyUnit = _context.ArmyUnits.Include(e => e.Options).FirstOrDefault(armyUnit => armyUnit.ArmyUnitId == id);

            if (selectedArmyUnit == null)
            {
                return NotFound();
            }

            return Ok(selectedArmyUnit);
        }

        // PUT: api/armyUnits/5
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

    }
}
