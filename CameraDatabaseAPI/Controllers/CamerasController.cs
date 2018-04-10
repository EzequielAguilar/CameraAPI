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
    [Route("api/Cameras")]
    public class CamerasController : Controller
    {
        private readonly CameraModel _context;

        public CamerasController(CameraModel context)
        {
            _context = context;
        }

        // GET: api/Cameras
        [HttpGet]
        public IEnumerable<Cameras> GetAlbums()
        {
            return _context.Cameras;
        }

        // GET: api/Cameras/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCameras([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cameras = await _context.Cameras.SingleOrDefaultAsync(m => m.cameraID == id);

            if (cameras == null)
            {
                return NotFound();
            }

            return Ok(cameras);
        }

        // PUT: api/Cameras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCameras([FromRoute] int id, [FromBody] Cameras cameras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cameras.cameraID)
            {
                return BadRequest();
            }

            _context.Entry(cameras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamerasExists(id))
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

        // POST: api/Cameras
        [HttpPost]
        public async Task<IActionResult> PostCameras([FromBody] Cameras cameras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cameras.Add(cameras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCameras", new { id = cameras.cameraID }, cameras);
        }

        // DELETE: api/Cameras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCameras([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cameras = await _context.Cameras.SingleOrDefaultAsync(m => m.cameraID == id);
            if (cameras == null)
            {
                return NotFound();
            }

            _context.Cameras.Remove(cameras);
            await _context.SaveChangesAsync();

            return Ok(cameras);
        }

        private bool CamerasExists(int id)
        {
            return _context.Cameras.Any(e => e.cameraID == id);
        }
    }
}