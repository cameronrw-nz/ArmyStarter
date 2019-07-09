using ArmyStarter.Api.Data;
using ArmyStarter.Models;
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
        [HttpGet("")]
        [HttpGet("armyId={armyId}")]
        public async Task<IActionResult> GetArmyUnits([FromRoute] string armyId = null)
        {
            if (armyId == null)
            {
                return Ok(_context.PlanArmyUnit);
            }

            var id = new Guid(armyId);
            return Ok(_context.PlanArmyUnit.Where(armyUnit => armyUnit.PlanArmyId == id));
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

            PlanUnit selectedArmyUnit = _context.PlanArmyUnit.Include(e => e.Options).FirstOrDefault(armyUnit => armyUnit.PlanArmyId == id);

            if (selectedArmyUnit == null)
            {
                return NotFound();
            }

            return Ok(selectedArmyUnit);
        }
    }
}
