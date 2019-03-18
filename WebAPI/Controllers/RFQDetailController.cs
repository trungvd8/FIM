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
    public class RFQDetailController : ControllerBase
    {
        private readonly RFQDBContext _context;

        public RFQDetailController(RFQDBContext context)
        {
            _context = context;
        }

        // GET: api/RFQDetail
        [HttpGet]
        public IEnumerable<RFQDetail> GetRFQDetails()
        {
            return _context.RFQDetails;
        }

        // GET: api/RFQDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRFQDetail([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rFQDetail = await _context.RFQDetails.FindAsync(id);

            if (rFQDetail == null)
            {
                return NotFound();
            }

            return Ok(rFQDetail);
        }

        // PUT: api/RFQDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRFQDetail([FromRoute] Guid id, [FromBody] RFQDetail rFQDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rFQDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(rFQDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RFQDetailExists(id))
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

        // POST: api/RFQDetail
        [HttpPost]
        public async Task<IActionResult> PostRFQDetail([FromBody] RFQDetail rFQDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RFQDetails.Add(rFQDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRFQDetail", new { id = rFQDetail.Id }, rFQDetail);
        }

        // DELETE: api/RFQDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRFQDetail([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rFQDetail = await _context.RFQDetails.FindAsync(id);
            if (rFQDetail == null)
            {
                return NotFound();
            }

            _context.RFQDetails.Remove(rFQDetail);
            await _context.SaveChangesAsync();

            return Ok(rFQDetail);
        }

        private bool RFQDetailExists(Guid id)
        {
            return _context.RFQDetails.Any(e => e.Id == id);
        }
    }
}