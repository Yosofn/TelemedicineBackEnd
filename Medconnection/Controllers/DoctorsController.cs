using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Context;
using DAL.DTOS.RequestDTO;
using BLL.Interfaces;
using BLL.Repositories;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly TelemedicineContext _context;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorsController(TelemedicineContext context,IDoctorRepository doctorRepository)
        {
            _context = context;
            _doctorRepository = doctorRepository;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
          if (_context.Doctors == null)
          {
              return NotFound();
          }
            return await _context.Doctors.ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
          if (_context.Doctors == null)
          {
              return NotFound();
          }
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(UpdateDoctorDTO doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
            return Ok();


        }

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
          if (_context.Doctors == null)
          {
              return Problem("Entity set 'TelemedicineContext.Doctors'  is null.");
          }
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (_context.Doctors == null)
            {
                return NotFound();
            }
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Route("RateDoctor")]
        public async Task<IActionResult> RateDoctor(int doc_Id,  int stars)
        {
            // Call the RateDoctor function from the BLL
            await _doctorRepository.RateDoctor(doc_Id, stars);

            return Ok();
        }




        private bool DoctorExists(int id)
        {
            return (_context.Doctors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
