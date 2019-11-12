using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VyKService.Models;

namespace VyKService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newQsController : ControllerBase
    {
        private readonly DB _context;

        public newQsController(DB context)
        {
            _context = context;
        }

        // GET: api/newQs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<newQ>>> GetnewQ()
        {
            return await _context.newQ.ToListAsync();
        }

        // GET: api/newQs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<newQ>> GetnewQ(int id)
        {
            var newQ = await _context.newQ.FindAsync(id);

            if (newQ == null)
            {
                return NotFound();
            }

            return newQ;
        }

        // PUT: api/newQs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutnewQ(int id, newQ newQ)
        {
            if (id != newQ.ID)
            {
                return BadRequest();
            }

            _context.Entry(newQ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!newQExists(id))
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

        // POST: api/newQs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<newQ>> PostnewQ(newQ newQ)
        {
            _context.newQ.Add(newQ);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetnewQ", new { id = newQ.ID }, newQ);
        }

        // DELETE: api/newQs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<newQ>> DeletenewQ(int id)
        {
            var newQ = await _context.newQ.FindAsync(id);
            if (newQ == null)
            {
                return NotFound();
            }

            _context.newQ.Remove(newQ);
            await _context.SaveChangesAsync();

            return newQ;
        }

        private bool newQExists(int id)
        {
            return _context.newQ.Any(e => e.ID == id);
        }
    }
}
