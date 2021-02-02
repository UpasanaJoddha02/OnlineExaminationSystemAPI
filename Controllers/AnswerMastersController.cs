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
    public class AnswerMastersController : ControllerBase
    {
        private readonly OESContext _context;

        public AnswerMastersController(OESContext context)
        {
            _context = context;
        }

        // GET: api/AnswerMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerMaster>>> GetAnswerMaster()
        {
            return await _context.AnswerMaster.ToListAsync();
        }

        // GET: api/AnswerMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerMaster>> GetAnswerMaster(int id)
        {
            var answerMaster = await _context.AnswerMaster.FindAsync(id);

            if (answerMaster == null)
            {
                return NotFound();
            }

            return answerMaster;
        }

        // PUT: api/AnswerMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerMaster(int id, AnswerMaster answerMaster)
        {
            if (id != answerMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerMasterExists(id))
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

        // POST: api/AnswerMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnswerMaster>> PostAnswerMaster(AnswerMaster answerMaster)
        {
            _context.AnswerMaster.Add(answerMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerMaster", new { id = answerMaster.Id }, answerMaster);
        }

        // DELETE: api/AnswerMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnswerMaster>> DeleteAnswerMaster(int id)
        {
            var answerMaster = await _context.AnswerMaster.FindAsync(id);
            if (answerMaster == null)
            {
                return NotFound();
            }

            _context.AnswerMaster.Remove(answerMaster);
            await _context.SaveChangesAsync();

            return answerMaster;
        }

        private bool AnswerMasterExists(int id)
        {
            return _context.AnswerMaster.Any(e => e.Id == id);
        }
    }
}
