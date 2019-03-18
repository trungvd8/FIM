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
    public class OrganizationController : ControllerBase
    {
        private readonly RFQDBContext _context;

        public OrganizationController(RFQDBContext context)
        {
            _context = context;
        }

        // GET: api/Organization
        [HttpGet]
        public IEnumerable<Organization> GetOrganizations()
        {
            return _context.Organizations;
        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganization([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organization = await _context.Organizations.Where(x => x.ParentId == id).ToListAsync();

            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        // PUT: api/Organization/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization([FromRoute] Guid id, [FromBody] Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organization.Id)
            {
                return BadRequest();
            }

            _context.Entry(organization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
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

        // POST: api/Organization
        [HttpPost]
        public async Task<IActionResult> PostOrganization([FromBody] Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();

            return Ok(organization);
        }

        private bool OrganizationExists(Guid id)
        {
            return _context.Organizations.Any(e => e.Id == id);
        }
    }
}