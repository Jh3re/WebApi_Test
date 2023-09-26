using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LN;
using Entities;
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

        [HttpPost]
        public async Task<ActionResult<Chair>> CreateChair(Chair chair)
        {
            if (chair == null)
            {
                return BadRequest("Datos de silla no validos.");
            }

            var newChair = await _chairService.CreateChairAsync(chair);

            if (newChair == null)
            {
                return StatusCode(500, "Error al crear el silla.");
            }

            return CreatedAtAction(nameof(GetChairById), new { id = newChair.Id }, newChair);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Chair>> PutUser(int id, Chair chair)
        {
            if (chair == null)
            {
                return BadRequest();
            }
            await _chairService.PutChairByIdAsync(id, chair);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Chair>> DeleteChair(int id)
        {
            var chair = await _chairService.DeleteChairByIdAsync(id);
            if (chair == null)
            {
                return NotFound();
            }
            return chair;
        }
    }
}