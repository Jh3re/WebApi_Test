using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChairController : Controller
    {
        private readonly IChairService _chairService;

        public ChairController(IChairService chairService)
        {
            _chairService = chairService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chair>>> GetChairs()
        {
            var chairs = await _chairService.GetAllChairsAsync();
            return Ok(chairs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chair>> GetChairById(int id)
        {
            var chair = await _chairService.GetChairByIdAsync(id);

            if (chair == null)
            {
                return NotFound();
            }

            return Ok(chair);
        }
    }
}