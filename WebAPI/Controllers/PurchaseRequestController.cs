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
    public class PurchaseRequestController : ControllerBase
    {
        private readonly RFQDBContext _context;

        public PurchaseRequestController(RFQDBContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseRequest
        [HttpGet]
        public IEnumerable<PurchaseRequest> GetPurchaseRequests()
        {
            return _context.PurchaseRequests;
        }

        // GET: api/PurchaseRequest/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseRequest([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchaseRequest = await _context.PurchaseRequests.FindAsync(id);

            if (purchaseRequest == null)
            {
                return NotFound();
            }

            return Ok(purchaseRequest);
        }

        // PUT: api/PurchaseRequest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseRequest([FromRoute] Guid id, [FromBody] PurchaseRequest purchaseRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseRequestExists(id))
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

        // POST: api/PurchaseRequest
        [HttpPost]
        public async Task<IActionResult> PostPurchaseRequest([FromBody] PurchaseRequest purchaseRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PurchaseRequests.Add(purchaseRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseRequest", new { id = purchaseRequest.Id }, purchaseRequest);
        }

        // DELETE: api/PurchaseRequest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseRequest([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchaseRequest = await _context.PurchaseRequests.FindAsync(id);
            if (purchaseRequest == null)
            {
                return NotFound();
            }

            _context.PurchaseRequests.Remove(purchaseRequest);
            await _context.SaveChangesAsync();

            return Ok(purchaseRequest);
        }

        private bool PurchaseRequestExists(Guid id)
        {
            return _context.PurchaseRequests.Any(e => e.Id == id);
        }
    }
}