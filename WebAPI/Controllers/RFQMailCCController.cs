using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFQMailCCController : ControllerBase
    {
        private readonly RFQDBContext _context;

        public RFQMailCCController(RFQDBContext context)
        {
            _context = context;
        }

        // GET: api/RFQMailCC
        [HttpGet]
        public IEnumerable<RFQMailCC> GetRFQMailCCs()
        {
            return _context.RFQMailCCs;
        }

        // GET: api/RFQMailCC/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRFQMailCC([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rFQMailCC = await _context.RFQMailCCs.FindAsync(id);

            if (rFQMailCC == null)
            {
                return NotFound();
            }

            return Ok(rFQMailCC);
        }

        /// <summary>
        /// Insert multi mail CCs of request of quotation
        /// </summary>
        /// <param name="rFQMailCCs"></param>
        /// <returns>rFQMailCCs</returns>
        [HttpPost]
        public async Task<IActionResult> PostRFQMailCC([FromBody] RFQMailCC[] rFQMailCCs)
        {
            // Check state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check item
            if (rFQMailCCs.Length == 0)
            {
                return NotFound();
            }

            // Perform insert and save
            _context.RFQMailCCs.AddRange(rFQMailCCs);
            await _context.SaveChangesAsync();

            // Return
            return Ok(rFQMailCCs);
        }

        /// <summary>
        /// Delete multi mail CCs of request of quotation
        /// </summary>
        /// <param name="rFQMailCCs"></param>
        /// <returns>rFQMailCCs</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteRFQMailCC([FromBody] RFQMailCC[] rFQMailCCs)
        {
            // Check state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check item
            if (rFQMailCCs.Length == 0)
            {
                return NotFound();
            }

            // Perform delete and save
            _context.RFQMailCCs.RemoveRange(rFQMailCCs);
            await _context.SaveChangesAsync();

            // Return
            return Ok(rFQMailCCs);
        }
    }
}