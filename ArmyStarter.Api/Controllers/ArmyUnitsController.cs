using ArmyStarter.Api.Data;
using ArmyStarter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyStarter.Api.Controllers
{
    [Route(Constants.BaseUrl + Constants.PlanUnitsRoute)]
    [ApiController]
    public class PlanUnitsController : ControllerBase
    {
        private readonly ArmyStarterContext _context;

        public PlanUnitsController(ArmyStarterContext context)
        {
            _context = context;
        }

        // GET: api/armyUnits
        [HttpGet]
        [HttpGet("")]
        [HttpGet("planArmyId={planArmyId}")]
        public async Task<IActionResult> GetPlanUnits([FromRoute] string armyId = null)
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
        public async Task<IActionResult> GetPlanUnit([FromRoute] string idString)
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
