using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineExaminationSystemAPI.Models;

namespace OnlineExaminationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestQuestionMappingsController : ControllerBase
    {
        private readonly OESContext _context;

        public TestQuestionMappingsController(OESContext context)
        {
            _context = context;
        }

        // GET: api/TestQuestionMappings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestQuestionMapping>>> GetTestQuestionMapping()
        {
            return await _context.TestQuestionMapping.ToListAsync();
        }

        // GET: api/TestQuestionMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestQuestionMapping>> GetTestQuestionMapping(int id)
        {
            var testQuestionMapping = await _context.TestQuestionMapping.FindAsync(id);

            if (testQuestionMapping == null)
            {
                return NotFound();
            }

            return testQuestionMapping;
        }

        // PUT: api/TestQuestionMappings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestQuestionMapping(int id, TestQuestionMapping testQuestionMapping)
        {
            if (id != testQuestionMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(testQuestionMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestQuestionMappingExists(id))
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

        // POST: api/TestQuestionMappings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestQuestionMapping>> PostTestQuestionMapping(TestQuestionMapping testQuestionMapping)
        {
            _context.TestQuestionMapping.Add(testQuestionMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuestionMapping", new { id = testQuestionMapping.Id }, testQuestionMapping);
        }

        // DELETE: api/TestQuestionMappings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestQuestionMapping>> DeleteTestQuestionMapping(int id)
        {
            var testQuestionMapping = await _context.TestQuestionMapping.FindAsync(id);
            if (testQuestionMapping == null)
            {
                return NotFound();
            }

            _context.TestQuestionMapping.Remove(testQuestionMapping);
            await _context.SaveChangesAsync();

            return testQuestionMapping;
        }

        private bool TestQuestionMappingExists(int id)
        {
            return _context.TestQuestionMapping.Any(e => e.Id == id);
        }
    }
}
