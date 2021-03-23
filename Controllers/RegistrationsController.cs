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
    public class RegistrationsController : ControllerBase
    {
        private readonly OESContext _context;

        public RegistrationsController(OESContext context)
        {
            _context = context;
        }

        // GET: api/Registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            return await _context.Registration.ToListAsync();
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        // PUT: api/Registrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, Registration registration)
        {
            if (id != registration.Id)
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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

        // POST: api/Registrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistration", new { id = registration.Id }, registration);
        }

        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();

            return registration;
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registration.Any(e => e.Id == id);
        }
        [HttpPost]
        [Route("CheckLogin")]
        public async Task<ActionResult<Registration>> CheckLogin(Registration objRegistration) {
            var registration = await  _context.Registration.Where(e => e.Email == objRegistration.Email && e.Password == objRegistration.Password).FirstOrDefaultAsync();
            if (registration == null)
            {
                return NotFound();
            }
            return registration;
        }
    }
}
