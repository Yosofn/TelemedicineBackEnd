using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Context;
using BLL.Interfaces;
using BLL.Repositories;
using DAL.DTOS.RequestDTO;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly TelemedicineContext _context;
        private readonly IAdminReposatory _adminRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AdminsController(TelemedicineContext context,IAdminReposatory adminReposatory,IDoctorRepository doctorRepository)
        {
            _context = context;
            _adminRepository = adminReposatory;
            _doctorRepository= doctorRepository;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
          if (_context.Admins == null)
          {
              return NotFound();
          }
            return await _context.Admins.ToListAsync();
        }

        // GET: api/Doctors
        [HttpGet("GetUnApprovedDoctors")]
        public async Task <IQueryable<Doctor>> GetUnApprovedDoctors()
        {
            var Doctors = _adminRepository.GetDoctorsStatus(1);
            if (Doctors == null)
            {
                return (IQueryable<Doctor>)NotFound();
            }
            return Doctors;

        }

        [HttpGet("GetApprovedDoctors")]
        public async Task<IQueryable<Doctor>> GetApprovedDoctors()
        {
            var Doctors = _adminRepository.GetDoctorsStatus(2);
            if (Doctors == null)
            {
                return (IQueryable<Doctor>)NotFound();
            }
            return Doctors;

        }

        [HttpPut("ApproveDoctor/{id}/{doctorStatus}")]
        public IActionResult ApproveDoctor(ApproveDoctorDTO approveDoctor)
        {
            var result = _adminRepository.ApproveDoctor(approveDoctor);


            return Ok(result);
        }

        [HttpPost("ApproveBooking")]
        public IActionResult ApproveBooking(AppointmentDTO approveBooking)
        {
            try
            {
                // Pass the appointment DTO to the repository method for approval
                var result = _adminRepository.ApproveBooking(approveBooking);

                if (result != null)
                {
                    // Return the approved appointment as a response
                    return Ok(result);
                }
                else
                {
                    return NotFound(); // Or any other appropriate HTTP status code
                }
            }
            catch (Exception ex)
            {
                // Handle any exception that occurs during the approval process
                return StatusCode(500, ex.Message); // Internal Server Error
            }
        }
        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
          if (_context.Admins == null)
          {
              return NotFound();
          }
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
          if (_context.Admins == null)
          {
              return Problem("Entity set 'TelemedicineContext.Admins'  is null.");
          }
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.Id }, admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            if (_context.Admins == null)
            {
                return NotFound();
            }
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminExists(int id)
        {
            return (_context.Admins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
