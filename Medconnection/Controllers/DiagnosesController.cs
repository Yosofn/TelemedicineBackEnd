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
    public class DiagnosesController : ControllerBase
    {
        private readonly TelemedicineContext _context;

        public DiagnosesController(TelemedicineContext context)
        {
            _context = context;
        }

        // GET: api/Diagnoses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diagnosis>>> GetDiagnoses()
        {
          if (_context.Diagnoses == null)
          {
              return NotFound();
          }
            return await _context.Diagnoses.ToListAsync();
        }

        // GET: api/Diagnoses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnosis>> GetDiagnosis(int id)
        {
          if (_context.Diagnoses == null)
          {
              return NotFound();
          }
            var diagnosis = await _context.Diagnoses.FindAsync(id);

            if (diagnosis == null)
            {
                return NotFound();
            }

            return diagnosis;
        }

        [HttpGet("GetPatientDiagnosis")]
        public async Task<ActionResult<Diagnosis>> GetPatientDiagnosis(int id)
        {
            if (_context.Diagnoses == null)
            {
                return NotFound();
            }
            var Diagnoses = _context.Diagnoses
                    .Where(Diagnoses => Diagnoses.PatientId == id)
                    .ToList();
            if (Diagnoses == null)
            {
                return NotFound();
            }

            return Ok(Diagnoses);
        }

        // PUT: api/Diagnoses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnosis(int id, Diagnosis diagnosis)
        {
            if (id != diagnosis.DiagnosisId)
            {
                return BadRequest();
            }

            _context.Entry(diagnosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosisExists(id))
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

        // POST: api/Diagnoses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PatientAddDiagnosis")]
        public async Task<ActionResult<Diagnosis>> PatientAddDiagnosis(DiagnosisDTO diagnosisDTO)
        {
          if (_context.Diagnoses == null)
          {
              return Problem("Entity set 'TelemedicineContext.Diagnoses'  is null.");
          }

            Diagnosis diagnosis = new Diagnosis()
            {
                  Diagnosis1= diagnosisDTO.Diagnosis1,
                  PatientId= diagnosisDTO.PatientId,

            };
            _context.Diagnoses.Add(diagnosis);
            
                await _context.SaveChangesAsync();
           
            

            return CreatedAtAction("GetDiagnosis", new { id = diagnosis.DiagnosisId }, diagnosis);
        }


        [HttpPost("DoctorAddDiagnosis")]
        public async Task<ActionResult<Diagnosis>> DoctorAddDiagnosis(DiagnosisDTO diagnosisDTO)
        {
            if (_context.Diagnoses == null)
            {
                return Problem("Entity set 'TelemedicineContext.Diagnoses'  is null.");
            }

            Diagnosis diagnosis = new Diagnosis()
            {
                Diagnosis1 = diagnosisDTO.Diagnosis1,
                DocId = diagnosisDTO.DocId,
                PatientId = diagnosisDTO.PatientId,

            };
            _context.Diagnoses.Add(diagnosis);

            await _context.SaveChangesAsync();



            return CreatedAtAction("GetDiagnosis", new { id = diagnosis.DiagnosisId }, diagnosis);
        }
        // DELETE: api/Diagnoses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosis(int id)
        {
            if (_context.Diagnoses == null)
            {
                return NotFound();
            }
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiagnosisExists(int id)
        {
            return (_context.Diagnoses?.Any(e => e.DiagnosisId == id)).GetValueOrDefault();
        }
    }
}
