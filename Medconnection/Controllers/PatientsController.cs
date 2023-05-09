﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using BLL.Interfaces;
using NuGet.Protocol.Core.Types;
using DAL.AutoMapper;
using DAL.DTOS.RequestDTO;
using Microsoft.AspNetCore.Authorization;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

           
        }
        // GET: api/Patients
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientRepository.GetAllAsync();
            if (patients == null)
            {
                return NotFound();
            }
            return Ok(patients);
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        
    }
     
        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }
            await _patientRepository.UpdateAsync(patient);
            return NoContent();
        }

    //    POST: api/Patients
     //   To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        //    POST: api/Patients/Register
        //   To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Register()")]
        public async Task<ActionResult<Patient>> RegisterPatient(PatientDTO patient)
            /*, [FromForm] FileUpload fileUpload*/

        {
           
          var  patient1=  _patientRepository.Register(patient);

            //try
            //{
            //    if (fileUpload.files.Length > 0)
            //    {
            //        await _patientRepository.SetImage(patient.NationalId, fileUpload.files);

            //    }
               
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
     
            return CreatedAtAction("GetPatient", patient1);
           
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

      
}
