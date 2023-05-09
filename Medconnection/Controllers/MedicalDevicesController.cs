using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Context;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalDevicesController : ControllerBase
    {
        private readonly TelemedicineContext _context;

        public MedicalDevicesController(TelemedicineContext context)
        {
            _context = context;
        }

        // GET: api/MedicalDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalDevice>>> GetMedicalDevices()
        {
          if (_context.MedicalDevices == null)
          {
              return NotFound();
          }
            return await _context.MedicalDevices.ToListAsync();
        }

        // GET: api/MedicalDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalDevice>> GetMedicalDevice(int id)
        {
          if (_context.MedicalDevices == null)
          {
              return NotFound();
          }
            var medicalDevice = await _context.MedicalDevices.FindAsync(id);

            if (medicalDevice == null)
            {
                return NotFound();
            }

            return medicalDevice;
        }

        // PUT: api/MedicalDevices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalDevice(int id, MedicalDevice medicalDevice)
        {
            if (id != medicalDevice.DeviceNumber)
            {
                return BadRequest();
            }

            _context.Entry(medicalDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalDeviceExists(id))
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

        // POST: api/MedicalDevices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalDevice>> PostMedicalDevice(MedicalDevice medicalDevice)
        {
          if (_context.MedicalDevices == null)
          {
              return Problem("Entity set 'TelemedicineContext.MedicalDevices'  is null.");
          }
            _context.MedicalDevices.Add(medicalDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalDevice", new { id = medicalDevice.DeviceNumber }, medicalDevice);
        }

        // DELETE: api/MedicalDevices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalDevice(int id)
        {
            if (_context.MedicalDevices == null)
            {
                return NotFound();
            }
            var medicalDevice = await _context.MedicalDevices.FindAsync(id);
            if (medicalDevice == null)
            {
                return NotFound();
            }

            _context.MedicalDevices.Remove(medicalDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalDeviceExists(int id)
        {
            return (_context.MedicalDevices?.Any(e => e.DeviceNumber == id)).GetValueOrDefault();
        }
    }
}
