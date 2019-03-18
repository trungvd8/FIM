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
    public class RequestForQuotationController : ControllerBase
    {
        private readonly RFQDBContext _context;

        public RequestForQuotationController(RFQDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all request for quotation
        /// GET: api/RequestForQuotation
        /// </summary>
        /// <returns>IEnumerable<RequestForQuotation></returns>
        [HttpGet]
        public IEnumerable<RequestForQuotation> GetRequestForQuotations()
        {
            return _context.RequestForQuotations;
        }

        // GET: api/RequestForQuotation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestForQuotation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requestForQuotation = await _context.RequestForQuotations.FindAsync(id);

            if (requestForQuotation == null)
            {
                return NotFound();
            }

            return Ok(requestForQuotation);
        }

        // PUT: api/RequestForQuotation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestForQuotation([FromRoute] Guid id, [FromBody] RequestForQuotation requestForQuotation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestForQuotation.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestForQuotation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestForQuotationExists(id))
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

        // POST: api/RequestForQuotation
        [HttpPost]
        public async Task<IActionResult> PostRequestForQuotation([FromBody] RequestForQuotation requestForQuotation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RequestForQuotations.Add(requestForQuotation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestForQuotation", new { id = requestForQuotation.Id }, requestForQuotation);
        }

        // DELETE: api/RequestForQuotation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestForQuotation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requestForQuotation = await _context.RequestForQuotations.FindAsync(id);
            if (requestForQuotation == null)
            {
                return NotFound();
            }

            _context.RequestForQuotations.Remove(requestForQuotation);
            await _context.SaveChangesAsync();

            return Ok(requestForQuotation);
        }

        private bool RequestForQuotationExists(Guid id)
        {
            return _context.RequestForQuotations.Any(e => e.Id == id);
        }
    }
}