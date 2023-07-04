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
    public class TreatmentsController : ControllerBase
    {
        private readonly TelemedicineContext _context;

        public TreatmentsController(TelemedicineContext context)
        {
            _context = context;
        }

        // GET: api/Treatments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treatment>>> GetTreatments()
        {
          if (_context.Treatments == null)
          {
              return NotFound();
          }
            return await _context.Treatments.ToListAsync();
        }

        // GET: api/Treatments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Treatment>> GetTreatment(int id)
        {
          if (_context.Treatments == null)
          {
              return NotFound();
          }
            var treatment = await _context.Treatments.FindAsync(id);

            if (treatment == null)
            {
                return NotFound();
            }

            return treatment;
        }

        [HttpGet("GetPatientTreatments")]
        public async Task<ActionResult<Treatment>> GetPatientTreatments(int id)
        {
            if (_context.Treatments == null)
            {
                return NotFound();
            }
            var Treatments = _context.Treatments
                    .Where(Treatment => Treatment.PatientId == id)
                    .ToList();
            if (Treatments == null)
            {
                return NotFound();
            }

            return Ok(Treatments);
        }
        // PUT: api/Treatments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreatment(int id, Treatment treatment)
        {
            if (id != treatment.TreatmentId)
            {
                return BadRequest();
            }

            _context.Entry(treatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentExists(id))
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

        // POST: api/Treatments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PatientAddTreatment")]
        public async Task<ActionResult<TreatmentsDTO>> PatientAddTreatment(TreatmentsDTO treatmentDTO)
        {
            if (treatmentDTO == null)
            {
                NoContent();
            }


            Treatment treatment = new Treatment()
            {
                Treatment1 = treatmentDTO.Treatment1,
                PatientId = treatmentDTO.PatientId,

            };
            _context.Treatments.Add(treatment);

            await _context.SaveChangesAsync();

            return Ok(treatment);
        }
        [HttpPost("DoctorAddTreatment")]
        public async Task<ActionResult<TreatmentsDTO>> DoctorAddTreatment(TreatmentsDTO treatmentDTO)
        {
          if (treatmentDTO == null)
          {
              NoContent();
          }


            Treatment treatment = new Treatment()
            {
                Treatment1 = treatmentDTO.Treatment1,
                PatientId= treatmentDTO.PatientId,
                DocId=treatmentDTO.DocId,

            };
            _context.Treatments.Add(treatment);

         await _context.SaveChangesAsync();

            return Ok(treatment);
        }

        // DELETE: api/Treatments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            if (_context.Treatments == null)
            {
                return NotFound();
            }
            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }

            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreatmentExists(int id)
        {
            return (_context.Treatments?.Any(e => e.TreatmentId == id)).GetValueOrDefault();
        }
    }
}
