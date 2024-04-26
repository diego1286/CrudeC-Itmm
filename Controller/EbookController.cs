using System.Data.Entity;
using ebooksItm.Data;
using ebooksItm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ebooksItm.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EbookController : ControllerBase
    {
           private readonly DataContext _context;

        public EbookController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Ebooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ebook>>> GetEbooks()
        {
            return await _context.Ebooks.ToListAsync();
        }

        // GET: api/Ebooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ebook>> GetEbook(int id)
        {
            var ebook = await _context.Ebooks.FindAsync(id);

            if (ebook == null)
            {
                return NotFound();
            }

            return ebook;
        }

        // POST: api/Ebooks
        [HttpPost]
        public async Task<ActionResult<Ebook>> PostEbook(Ebook ebook)
        {
            _context.Ebooks.Add(ebook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEbook", new { id = ebook.Id }, ebook);
        }

        // PUT: api/Ebooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEbook(int id, Ebook ebook)
        {
            if (id != ebook.Id)
            {
                return BadRequest();
            }

            _context.Entry(ebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EbookExists(id))
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

        // DELETE: api/Ebooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEbook(int id)
        {
            var ebook = await _context.Ebooks.FindAsync(id);
            if (ebook == null)
            {
                return NotFound();
            }

            _context.Ebooks.Remove(ebook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EbookExists(int id)
        {
            return _context.Ebooks.Any(e => e.Id == id);
        }

    }
}