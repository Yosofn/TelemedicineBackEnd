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

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly TelemedicineContext _context;

        public ReportsController(TelemedicineContext context)
        {
            _context = context;
        }

        // GET: api/Reports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
          if (_context.Reports == null)
          {
              return NotFound();
          }
            return await _context.Reports.ToListAsync();
        }

        // GET: api/Reports/5
        [HttpGet("GetPatientReprt")]
        public async Task<ActionResult<Report>> GetPatientReprt(int id)
        {
            if (_context.Reports == null)
            {
                return NotFound();
            }
            var Reports = _context.Reports
                    .Where(Report => Report.PatientId == id)
                    .ToList();
            if (Reports == null)
            {
                return NotFound();
            }

            return Ok(Reports);
        }

        // PUT: api/Reports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, Report report)
        {
            if (id != report.ReportId)
            {
                return BadRequest();
            }

            _context.Entry(report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(id))
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

        // POST: api/Reports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PatientAddReport")]
        public async Task<IActionResult> PatientAddReport(ReportDTO report)
        {
          if (_context.Reports == null)
          {
              return Problem("Entity set 'TelemedicineContext.Reports'  is null.");
          }

            Report Report = new Report
            {
                Report1 = report.Report,
                PatientId = report.PatientId,
            };
            _context.Reports.Add(Report);
             _context.SaveChangesAsync();

            return Ok(Report);
        }


        [HttpPost("DoctorAddReport")]
        public async Task<IActionResult> DoctorAddReport(ReportDTO report)
        {
            if (_context.Reports == null)
            {
                return Problem("Entity set 'TelemedicineContext.Reports'  is null.");
            }

            Report Report = new Report
            {
                Report1 = report.Report,
                DocId = report.doctorId,
                PatientId = report.PatientId,

            };
            _context.Reports.Add(Report);
            _context.SaveChangesAsync();

            return Ok(Report);
        }

        [HttpPost("MedicalDeviceAddReport")]
        public async Task<IActionResult> MedicalDeviceAddReport(ReportDTO report)
        {
            if (_context.Reports == null)
            {
                return Problem("Entity set 'TelemedicineContext.Reports'  is null.");
            }

            Report Report = new Report
            {
                Report1 = report.Report,
                DeviceNumber = report.DeviceNumber,
                PatientId = report.PatientId,

            };
            _context.Reports.Add(Report);
            _context.SaveChangesAsync();

            return Ok(Report);
        }
        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            if (_context.Reports == null)
            {
                return NotFound();
            }
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportExists(int id)
        {
            return (_context.Reports?.Any(e => e.ReportId == id)).GetValueOrDefault();
        }
    }
}
