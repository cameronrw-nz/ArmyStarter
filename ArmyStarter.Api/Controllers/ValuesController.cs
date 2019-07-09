using System.Threading.Tasks;
using ArmyStarter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArmyStarter.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/Armies
        [HttpGet]
        public async Task<IActionResult> GetArmy()
        {
            return Ok(new PlanArmy());
        }
    }
}