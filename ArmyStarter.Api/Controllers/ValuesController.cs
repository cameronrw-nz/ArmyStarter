using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmyStarter.Api.Models;
using Microsoft.AspNetCore.Http;
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
            return Ok(new Army());
        }
    }
}