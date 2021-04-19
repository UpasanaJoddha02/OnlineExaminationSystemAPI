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
    public class QuestionMastersController : ControllerBase
    {
        private readonly OESContext _context;

        public QuestionMastersController(OESContext context)
        {
            _context = context;
        }

        // GET: api/QuestionMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionMaster>>> GetQuestionMaster()
        {
            return await _context.QuestionMaster.ToListAsync();
        }

        [HttpGet]
        [Route("GetQuestions/{createdBy}")]
        public async Task<ActionResult<IEnumerable<QuestionMaster>>> GetQuestions(int createdBy)
        {
            //var questions = await _context.QuestionMaster.FindAsync(createdBy);
            var questions = await _context.QuestionMaster.Where(e => e.CreatedBy == createdBy).ToListAsync();
            if (questions == null)
            {
                return NotFound();
            }
            return questions;
            //return await _context.QuestionMaster.ToListAsync();
        }

        [HttpGet]
        [Route("GetQuestionsByTestId/{TestId}")]
        public async Task<ActionResult<IEnumerable<QuestionMaster>>> GetQuestionsByTestId(int TestId)
        {
            //var questions = await _context.QuestionMaster.FindAsync(createdBy);
            //var questions = await _context.QuestionMaster.Where(e => e.CreatedBy == createdBy).ToListAsync();

            //var questions = await _context.QuestionMaster.Join(_context.TestQuestionMapping,
            //                                                        QM => QM.Id,
            //                                                        TQM => TQM.QuestionId,
            //                                                        (QM, TQM) => new { service = QM, asgnmt = TQM })
            //                                                .Where(ssa => ssa.asgnmt.TestId == TestId)
            //                                                .Select(ssa => ssa.service);
            var questions = await (from QM in _context.QuestionMaster
                             join TQM in _context.TestQuestionMapping on QM.Id equals TQM.QuestionId
                             where TQM.TestId == TestId
                             select QM).ToListAsync();


            if (questions == null)
            {
                return NotFound();
            }
            return questions;
            //return await _context.QuestionMaster.ToListAsync();
        }

        // GET: api/QuestionMasters/5
        [HttpGet("{id}")]

        public async Task<ActionResult<QuestionMaster>> GetQuestionMaster(int id)
        {
            var questionMaster = await _context.QuestionMaster.FindAsync(id);

            if (questionMaster == null)
            {
                return NotFound();
            }

            return questionMaster;
        }

        // PUT: api/QuestionMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]

        public async Task<IActionResult> PutQuestionMaster(int id, QuestionMaster questionMaster)
        {
            if (id != questionMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionMasterExists(id))
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

        // POST: api/QuestionMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QuestionMaster>> PostQuestionMaster(QuestionMaster questionMaster)
        {
            _context.QuestionMaster.Add(questionMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionMaster", new { id = questionMaster.Id }, questionMaster);
        }

        // DELETE: api/QuestionMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionMaster>> DeleteQuestionMaster(int id)
        {
            var questionMaster = await _context.QuestionMaster.FindAsync(id);
            if (questionMaster == null)
            {
                return NotFound();
            }

            _context.QuestionMaster.Remove(questionMaster);
            await _context.SaveChangesAsync();

            return questionMaster;
        }

        private bool QuestionMasterExists(int id)
        {
            return _context.QuestionMaster.Any(e => e.Id == id);
        }
    }
}
