using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GForms.Server.Data;
using GForms.Shared;

namespace GForms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerVariantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnswerVariantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/AnswerVariants
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AnswerVariant>>> GetAnswerVariants(int questionId)
        //{
        //    if (_context.AnswerVariants == null)
        //    {
        //        return NotFound();
        //    }

        //    var answerVariants = await _context.AnswerVariants
        //        .Include(t => t.Question)
        //        .Where(t => t.Question.Id == questionId)
        //        .ToListAsync();

        //    return answerVariants;

        //    //if (_context.AnswerVariants == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //  return await _context.AnswerVariants.ToListAsync();
        //}

        // GET: api/AnswerVariants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerVariant>>> GetAllAnswerVariants()
        {
            if (_context.AnswerVariants == null)
            {
                return NotFound();
            }
            var answerVariants = _context.AnswerVariants
                .Include(q => q.Question)
                .ToListAsync();
            return await answerVariants;
        }

        // GET: api/AnswerVariants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerVariant>> GetAnswerVariant(int id)
        {
          if (_context.AnswerVariants == null)
          {
              return NotFound();
          }
            var answerVariant = await _context.AnswerVariants.FindAsync(id);

            if (answerVariant == null)
            {
                return NotFound();
            }

            return answerVariant;
        }

        // PUT: api/AnswerVariants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerVariant(int id, AnswerVariant answerVariant)
        {
            if (id != answerVariant.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerVariant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerVariantExists(id))
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

        // POST: api/AnswerVariants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnswerVariant>> PostAnswerVariant(AnswerVariant answerVariant)
        {
          if (_context.AnswerVariants == null)
          {
              return Problem("Entity set 'ApplicationDbContext.AnswerVariants'  is null.");
          }
            _context.AnswerVariants.Add(answerVariant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerVariant", new { id = answerVariant.Id }, answerVariant);
        }

        // DELETE: api/AnswerVariants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerVariant(int id)
        {
            if (_context.AnswerVariants == null)
            {
                return NotFound();
            }
            var answerVariant = await _context.AnswerVariants.FindAsync(id);
            if (answerVariant == null)
            {
                return NotFound();
            }

            _context.AnswerVariants.Remove(answerVariant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerVariantExists(int id)
        {
            return (_context.AnswerVariants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
