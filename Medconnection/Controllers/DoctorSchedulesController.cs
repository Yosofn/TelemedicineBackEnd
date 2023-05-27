using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using DAL.DTOS.RequestDTO;
using System.Numerics;
using AutoMapper;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorSchedulesController : ControllerBase
    {
        private readonly TelemedicineContext _context;
        private readonly IMapper _mapper;

        public DoctorSchedulesController(TelemedicineContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DoctorSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TempDoctorSchedule>>> GetDoctorSchedules()
        {
          if (_context.TempDoctorSchedules == null)
          {
              return NotFound();
          }
            return await _context.TempDoctorSchedules.ToListAsync();
        }

        // GET: api/DoctorSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TempDoctorSchedule>> GetDoctorSchedule(int id)
        {
          if (_context.TempDoctorSchedules == null)
          {
              return NotFound();
          }
            var doctorSchedule = await _context.TempDoctorSchedules.FindAsync(id);

            if (doctorSchedule == null)
            {
                return NotFound();
            }

            return doctorSchedule;
        }

        // PUT: api/DoctorSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorSchedule(int id, TempDoctorSchedule doctorSchedule)
        {
            if (id != doctorSchedule.ScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(doctorSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorScheduleExists(id))
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

        // POST: api/DoctorSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TempDoctorSchedule>> PostDoctorSchedule(DoctorSchedualeDTO doctorSchedule)
        {
          if (_context.TempDoctorSchedules == null)
          {
              return Problem("Entity set 'TelemedicineContext.DoctorSchedules'  is null.");
          }
            var currentScheduale = _mapper.Map<TempDoctorSchedule>(doctorSchedule);

            _context.TempDoctorSchedules.Add(currentScheduale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoctorScheduleExists(currentScheduale.ScheduleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDoctorSchedule", currentScheduale);
        }

        // DELETE: api/DoctorSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorSchedule(int id)
        {
            if (_context.TempDoctorSchedules == null)
            {
                return NotFound();
            }
            var doctorSchedule = await _context.TempDoctorSchedules.FindAsync(id);
            if (doctorSchedule == null)
            {
                return NotFound();
            }

            _context.TempDoctorSchedules.Remove(doctorSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorScheduleExists(int id)
        {
            return (_context.TempDoctorSchedules?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}
