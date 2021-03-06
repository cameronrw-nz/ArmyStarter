﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyStarter.Api.Data;
using ArmyStarter.Models;

namespace ArmyStarter.Api.Controllers
{
    [Route(Constants.BaseUrl + Constants.ArmiesRoute)]
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
            return Ok( _context.GetAllArmyContent());
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

            PlanArmy selectedArmy = _context.PlanArmy.Include(e => e.PlanUnits).ThenInclude(e => e.Options).FirstOrDefault(army => army.PlanArmyId == id);

            if (selectedArmy == null)
            {
                return NotFound();
            }

            return Ok(selectedArmy);
        }

        // PUT: api/Armies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmy([FromRoute] Guid id, [FromBody] PlanArmy army)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != army.PlanArmyId)
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
        public async Task<IActionResult> PostArmy([FromBody] PlanArmy army)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlanArmy.Add(army);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArmy", new { id = army.PlanArmyId }, army);
        }

        // DELETE: api/Armies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArmy([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var army = await _context.PlanArmy.FindAsync(id);
            if (army == null)
            {
                return NotFound();
            }

            _context.PlanArmy.Remove(army);
            await _context.SaveChangesAsync();

            return Ok(army);
        }

        private bool ArmyExists(Guid id)
        {
            return _context.PlanArmy.Any(e => e.PlanArmyId == id);
        }
    }
}