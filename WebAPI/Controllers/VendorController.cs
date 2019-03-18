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
    public class VendorController : ControllerBase
    {
        private readonly RFQDBContext _context;

        public VendorController(RFQDBContext context)
        {
            _context = context;
        }

        // GET: api/Vendor
        [HttpGet]
        public IEnumerable<Vendor> GetVendors()
        {
            return _context.Vendors;
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor([FromRoute] Guid id, [FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
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

        // POST: api/Vendor
        [HttpPost]
        public async Task<IActionResult> PostVendor([FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return Ok(vendor);
        }

        private bool VendorExists(Guid id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }
    }
}