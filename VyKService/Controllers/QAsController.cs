using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using VyKService.Models;

namespace VyKService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QAsController : ControllerBase
    {
        private readonly DB _context;

        public QAsController(DB context)
        {
            _context = context;
        }

        // GET: api/QAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QA>>> GetQA()
        {
            return await _context.QA.ToListAsync();
        }

        // GET: api/QAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QA>> GetQA(int id)
        {
            var qA = await _context.QA.FindAsync(id);

            if (qA == null)
            {
                return NotFound();
            }

            return qA;
        } 
        
        
        // PUT: api/QAs/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for
         // more details see https://aka.ms/RazorPagesCRUD.


        [HttpPut("{id}")]
        public async Task<IActionResult> PutQA(int id, int vote)
        {

            try
            {
                var question = _context.QA.Find(id);
                question.Votes += vote;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QAExists(id))
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

        // POST: api/QAs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<QA>> PostQA(newQ qA)
        {
           _context.newQ.Add(qA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQA", new { id = qA.ID }, qA);
        }

        // DELETE: api/QAs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QA>> DeleteQA(int id)
        {
            var qA = await _context.QA.FindAsync(id);
            if (qA == null)
            {
                return NotFound();
            }

            _context.QA.Remove(qA);
            await _context.SaveChangesAsync();

            return qA;
        }

        private bool QAExists(int id)
        {
            return _context.QA.Any(e => e.ID == id);
        }
    }
}
