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
    public class TestMastersController : ControllerBase
    {
        private readonly OESContext _context;

        public TestMastersController(OESContext context)
        {
            _context = context;
        }

        // GET: api/TestMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestMaster>>> GetTestMaster()
        {
            return await _context.TestMaster.ToListAsync();
        }

        // GET: api/TestMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestMaster>> GetTestMaster(int id)
        {
            var testMaster = await _context.TestMaster.FindAsync(id);

            if (testMaster == null)
            {
                return NotFound();
            }

            return testMaster;
        }

        // PUT: api/TestMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestMaster(int id, TestMaster testMaster)
        {
            if (id != testMaster.TestId)
            {
                return BadRequest();
            }

            _context.Entry(testMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestMasterExists(id))
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

        // POST: api/TestMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestMaster>> PostTestMaster(TestMaster testMaster)
        {
            _context.TestMaster.Add(testMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestMaster", new { id = testMaster.TestId }, testMaster);
        }

        // DELETE: api/TestMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestMaster>> DeleteTestMaster(int id)
        {
            var testMaster = await _context.TestMaster.FindAsync(id);
            if (testMaster == null)
            {
                return NotFound();
            }

            _context.TestMaster.Remove(testMaster);
            await _context.SaveChangesAsync();

            return testMaster;
        }

        private bool TestMasterExists(int id)
        {
            return _context.TestMaster.Any(e => e.TestId == id);
        }
    }
}
