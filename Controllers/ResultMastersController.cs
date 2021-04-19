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
    public class ResultMastersController : ControllerBase
    {
        private readonly OESContext _context;

        public ResultMastersController(OESContext context)
        {
            _context = context;
        }

        // GET: api/ResultMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultMaster>>> GetResultMaster()
        {
            return await _context.ResultMaster.ToListAsync();
        }
        [HttpGet("{TestId}/{StudentId}")]
        public async Task<ActionResult<IEnumerable<CalculatedResult>>> GetResultMasterById(int TestId, int StudentId)
        {
            //List<CalculatedResult> calculatedResult;
            var result = await _context.CalculatedResult.FromSqlRaw("SELECT ISNULL(SUM(QM.Marks),0) AS TotalMarks, COUNT(*) AS TotalCorrectAnswers FROM QuestionMaster QM INNER JOIN AnswerMaster AM ON AM.QuestionId = QM.Id AND AM.SelectedAnswer = QM.Answer AND AM.StudentId = " + StudentId + " WHERE QM.Id IN(SELECT QuestionId FROM AnswerMaster WHERE TestId = " + TestId + " AND StudentId = " + StudentId + ")").ToListAsync();

            //var marks = await (from QM in _context.QuestionMaster
            //                   join AM in _context.AnswerMaster on QM.Id equals AM.QuestionId
            //                   //where QM.Id in (select AM.QuestionId where AM.TestId = 6 and AM.StudentId = 2) select S);  

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
        // GET: api/ResultMasters/5
        [HttpGet("{StudentId}")]

        public async Task<ActionResult<IEnumerable<ResultList>>> GetResultMaster(int StudentId)
        {
            var resultMaster = await _context.ResultList.FromSqlRaw("SELECT TM.TestName,TM.TestId,RM.Marks FROM TestMaster AS TM LEFT JOIN ResultMaster AS RM ON RM.TestId = TM.TestId AND RM.StudentId = " + StudentId + " WHERE TM.TestId IN(SELECT TestId FROM ResultMaster WHERE StudentId = " + StudentId + ")").ToListAsync();

            if (resultMaster == null)
            {
                return NotFound();
            }

            return resultMaster;
        }

        // PUT: api/ResultMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultMaster(int id, ResultMaster resultMaster)
        {
            if (id != resultMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(resultMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultMasterExists(id))
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

        // POST: api/ResultMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ResultMaster>> PostResultMaster(ResultMaster resultMaster)
        {
            _context.ResultMaster.Add(resultMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResultMaster", new { id = resultMaster.Id }, resultMaster);
        }

        // DELETE: api/ResultMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultMaster>> DeleteResultMaster(int id)
        {
            var resultMaster = await _context.ResultMaster.FindAsync(id);
            if (resultMaster == null)
            {
                return NotFound();
            }

            _context.ResultMaster.Remove(resultMaster);
            await _context.SaveChangesAsync();

            return resultMaster;
        }

        private bool ResultMasterExists(int id)
        {
            return _context.ResultMaster.Any(e => e.Id == id);
        }
    }
}
