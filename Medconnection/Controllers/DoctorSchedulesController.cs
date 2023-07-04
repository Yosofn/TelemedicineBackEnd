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
        public async Task<ActionResult<IEnumerable<DoctorSchedule>>> GetDoctorSchedules()
        {
          if (_context.DoctorSchedules == null)
          {
              return NotFound();
          }
            return await _context.DoctorSchedules.ToListAsync();
        }

        // GET: api/DoctorSchedules/5
        [HttpPost("GetDoctorSchedule")]
        public async Task<ActionResult<DoctorSchedule>> GetDoctorSchedule(int DoctorId)
        {
          if (_context.DoctorSchedules == null)
          {
              return NotFound();
          }
            var schedules = _context.DoctorSchedules
                    .Where(schedule => schedule.DoctorId == DoctorId)
                    .ToList();
            if (schedules == null)
            {
                return NotFound();
            }

            return Ok(schedules);
        }

        // PUT: api/DoctorSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorSchedule(int id, DoctorSchedule doctorSchedule)
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
        public async Task<ActionResult<DoctorSchedule>> PostDoctorSchedule(DoctorSchedualeDTO doctorSchedule)
        {
          if (_context.DoctorSchedules == null)
          {
              return Problem("Entity set 'TelemedicineContext.DoctorSchedules'  is null.");
          }
            var currentScheduale = _mapper.Map<DoctorSchedule>(doctorSchedule);

            _context.DoctorSchedules.Add(currentScheduale);
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

            return currentScheduale;
        }

        // DELETE: api/DoctorSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorSchedule(int id)
        {
            if (_context.DoctorSchedules == null)
            {
                return NotFound();
            }
            var doctorSchedule = await _context.DoctorSchedules.FindAsync(id);
            if (doctorSchedule == null)
            {
                return NotFound();
            }

            _context.DoctorSchedules.Remove(doctorSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorScheduleExists(int id)
        {
            return (_context.DoctorSchedules?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}
