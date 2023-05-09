﻿using AutoMapper;
using BLL.Interfaces;
using DAL.AutoMapper;
using DAL.Context;
using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly TelemedicineContext _context;
        private readonly IMapper _patientMapper;

        public PatientRepository(TelemedicineContext context, IMapper patientMapper)
        {
            _context = context;
            _patientMapper = patientMapper;

    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }
        public async Task Register(PatientDTO patient)
        {
            var currentPatient = _patientMapper.Map<Patient>(patient);
            _context.Patients.Add(currentPatient);
            await _context.SaveChangesAsync();
        }

        public AuthResponse Registration(PatientDTO patient)
        {
            var p = _context.Patients.Any(x => x.Username.Equals(patient.Username));
            if (_context.Patients.Any(x => x.Username.Equals(patient.Username)))
            {
                return new AuthResponse { Success = false };
            }
            //automapping problem (profile picture)


            var currentPatient = _patientMapper.Map<Patient>(patient);

            
            Patient patient1 = new Patient()
            {
                Password = currentPatient.Password,
                Username = currentPatient.Username,
                Fname = currentPatient.Username,
                Lname = currentPatient.Username,
                NationalId = currentPatient.NationalId,
                ProfileStatus = currentPatient.ProfileStatus,
                Age =currentPatient.Age,
                Address = currentPatient.Address,
                Height = currentPatient.Height,
                Weight  = currentPatient.Weight,
                Job = currentPatient.Job,
                Phone = currentPatient.Phone,
                Gender = currentPatient.Gender, 
                MaritalStatus   = currentPatient.MaritalStatus,

            };
          //  _context.Patients.Add(currentPatient);
            _context.Patients.Add(patient1);

            _context.SaveChangesAsync();
            return new AuthResponse { Success = true};

        }
    
            public async Task UpdateAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new ArgumentException($"Patient with ID {id} not found.");
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> PatientExistsAsync(int id)
        {
            return await _context.Patients.AnyAsync(p => p.Id == id);
        }

        public AuthResponse UserLogin(UserLoginDTO userLogin)
        {

         var currentUser = _context.Patients
                .Where(x => x.Username.Equals(userLogin.Username) && x.Password.Equals(userLogin.Password)).SingleOrDefault();
            if (currentUser != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to my key"));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var data = new List<Claim>();
                data.Add(new Claim("Id", currentUser.Id.ToString()));
                data.Add(new Claim("Role", currentUser.ProfileStatus.ToString()));
                data.Add(new Claim("UserName", currentUser.Username.ToString()));

                var token = new JwtSecurityToken(
                claims: data,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
                return new AuthResponse { Token = new JwtSecurityTokenHandler().WriteToken(token), Success = true};

            }
            else
            {
                var AdminUser = _context.Admins
                    .Where(x => x.Username.Equals(userLogin.Username) && x.Password.Equals(userLogin.Password)).SingleOrDefault();

                if (AdminUser != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to my key"));

                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var data = new List<Claim>();
                    data.Add(new Claim("Id", AdminUser.Id.ToString()));
                    data.Add(new Claim("Role", AdminUser.ProfileStatus.ToString()));
                    data.Add(new Claim("UserName", AdminUser.Username.ToString()));


                    var token = new JwtSecurityToken(
                    claims: data,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);
                    return new AuthResponse { Token = new JwtSecurityTokenHandler().WriteToken(token), Success = true };

                }

                else
                {
                    var medicalDevice = _context.MedicalDevices
                        .Where(x => x.Username.Equals(userLogin.Username) && x.Password.Equals(userLogin.Password)).SingleOrDefault();

                    if (medicalDevice != null)
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to my key"));

                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var data = new List<Claim>();
                        data.Add(new Claim("Id", medicalDevice.DeviceNumber.ToString()));
                        data.Add(new Claim("Role", medicalDevice.ProfileStatus.ToString()));
                        data.Add(new Claim("UserName", medicalDevice.Username.ToString()));


                        var token = new JwtSecurityToken(
                        claims: data,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials);
                        return new AuthResponse { Token = new JwtSecurityTokenHandler().WriteToken(token), Success = true };

                    }
                }
            }

            return new AuthResponse { Success = false };
                
        }

        public async Task<Patient> GetByNationalIdAsync(UserInformationDTO userInformation)
        {
            var patient = _context.Patients
                .Where(x => x.Id.Equals(userInformation.Id)).FirstOrDefault();

            return patient;
        }

 


       

    }


}
