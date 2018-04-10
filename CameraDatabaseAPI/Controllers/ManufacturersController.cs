using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraDatabaseAPI.Models;

namespace CameraDatabaseAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Manufacturers")]
    public class ManufacturersController : Controller
    {
        private readonly CameraModel _context;

        public ManufacturersController(CameraModel context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public IEnumerable<Manufacturers> GetManufacturers()
        {
            return _context.Manufacturers;
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturers = await _context.Manufacturers.SingleOrDefaultAsync(m => m.companyID == id);

            if (manufacturers == null)
            {
                return NotFound();
            }

            return Ok(manufacturers);
        }

        // PUT: api/Manufacturers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturers([FromRoute] int id, [FromBody] Manufacturers manufacturers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturers.companyID)
            {
                return BadRequest();
            }

            _context.Entry(manufacturers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturersExists(id))
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

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<IActionResult> PostManufacturers([FromBody] Manufacturers manufacturers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Manufacturers.Add(manufacturers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturers", new { id = manufacturers.companyID }, manufacturers);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturers = await _context.Manufacturers.SingleOrDefaultAsync(m => m.companyID == id);
            if (manufacturers == null)
            {
                return NotFound();
            }

            _context.Manufacturers.Remove(manufacturers);
            await _context.SaveChangesAsync();

            return Ok(manufacturers);
        }

        private bool ManufacturersExists(int id)
        {
            return _context.Manufacturers.Any(e => e.companyID == id);
        }
    }
}