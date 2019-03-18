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
    public class PRDetailController : ControllerBase
    {
        private readonly RFQDBContext _context;

        public PRDetailController(RFQDBContext context)
        {
            _context = context;
        }

        // GET: api/PRDetail
        [HttpGet]
        public IEnumerable<PRDetail> GetPRDetails()
        {
            return _context.PRDetails;
        }

        // GET: api/PRDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPRDetail([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pRDetail = await _context.PRDetails.FindAsync(id);

            if (pRDetail == null)
            {
                return NotFound();
            }

            return Ok(pRDetail);
        }

        // PUT: api/PRDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPRDetail([FromRoute] Guid id, [FromBody] PRDetail pRDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(pRDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRDetailExists(id))
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

        // POST: api/PRDetail
        [HttpPost]
        public async Task<IActionResult> PostPRDetail([FromBody] PRDetail pRDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PRDetails.Add(pRDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPRDetail", new { id = pRDetail.Id }, pRDetail);
        }

        // DELETE: api/PRDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePRDetail([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pRDetail = await _context.PRDetails.FindAsync(id);
            if (pRDetail == null)
            {
                return NotFound();
            }

            _context.PRDetails.Remove(pRDetail);
            await _context.SaveChangesAsync();

            return Ok(pRDetail);
        }

        private bool PRDetailExists(Guid id)
        {
            return _context.PRDetails.Any(e => e.Id == id);
        }
    }
}