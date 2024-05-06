using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GForms.Server.Data;
using GForms.Shared;
using System.Security.Claims;

namespace GForms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Tests
        [HttpGet]
        public async Task<ActionResult<List<Test>>> GetTests()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_context.Tests == null)
            {
                return NotFound();
            }

            var tests = await _context.Tests
                .Include(t => t.ApplicationUser)
                .Where(t => t.ApplicationUser.Id == userId)
                .ToListAsync();

            return tests;
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            if (_context.Tests == null)
            {
                return NotFound();
            }
            var test = await _context.Tests
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        // PUT: api/Tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id, Test test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }

            _context.Entry(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        // POST: api/Tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            if (_context.Tests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tests'  is null.");
            }
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTest", new { id = test.Id }, test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            if (_context.Tests == null)
            {
                return NotFound();
            }
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestExists(int id)
        {
            return (_context.Tests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
