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
using System.Security.Cryptography;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAttacmentsController : ControllerBase
    {
        private readonly TelemedicineContext _context;
        private readonly IMapper _mapper;

        public DoctorAttacmentsController(TelemedicineContext context, IMapper mapper)
        {
             _mapper=mapper;
            _context = context;
        }

        // GET: api/DoctorAttacments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocAttacment>>> GetDocAttacments()
        {
          if (_context.DocAttacments == null)
          {
              return NotFound();
          }
            return await _context.DocAttacments.ToListAsync();
        }

        // GET: api/DoctorAttacments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocAttacment>> GetDocAttacment(int id)
        {
          if (_context.DocAttacments == null)
          {
              return NotFound();
          }
            var docAttacment = await _context.DocAttacments.FindAsync(id);

            if (docAttacment == null)
            {
                return NotFound();
            }

            return docAttacment;
        }


        [HttpGet("GetDoctorAttacmentByDoctorID")]
        public async Task<ActionResult<DocAttacment>> GetDoctorAttacmentByDoctorID(int DocId)
        {
            if (_context.DocAttacments == null)
            {
                return NotFound();
            }
            var docAttacment = _context.DocAttacments
                            .Where(Attachment => Attachment.DocId == DocId)
                                .ToList();
            if (docAttacment == null)
            {
                return NotFound();
            }

            return Ok(docAttacment);
        }



        // PUT: api/DoctorAttacments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocAttacment(int id, DocAttacment docAttacment)
        {
            if (id != docAttacment.Id)
            {
                return BadRequest();
            }

            _context.Entry(docAttacment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocAttacmentExists(id))
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

        // POST: api/DoctorAttacments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocAttacment>> PostDocAttacment(DoctorFilesDTO docAttacment)
        {
          if (_context.DocAttacments == null)
          {
              return Problem("Entity set 'TelemedicineContext.DocAttacments'  is null.");
          }
            var Attachment = _mapper.Map<DocAttacment>(docAttacment);
            _context.DocAttacments.Add(Attachment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocAttacment", new { id = Attachment.Id }, Attachment);
        }

        // DELETE: api/DoctorAttacments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocAttacment(int id)
        {
            if (_context.DocAttacments == null)
            {
                return NotFound();
            }
            var docAttacment = await _context.DocAttacments.FindAsync(id);
            if (docAttacment == null)
            {
                return NotFound();
            }

            _context.DocAttacments.Remove(docAttacment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocAttacmentExists(int id)
        {
            return (_context.DocAttacments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
