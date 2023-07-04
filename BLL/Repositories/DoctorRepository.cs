using AutoMapper;
using BLL.Interfaces;
using DAL.AutoMapper;
using DAL.Context;
using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly TelemedicineContext _context;
        private readonly IMapper _mapper;

        public DoctorRepository(TelemedicineContext context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;

        }

        public async Task JoinOurTeam(JoinOurTeamDTO doctor)
        {

            var patient = await _context.Patients.FindAsync(doctor.Id);


            if (_context.Doctors.Any(x => x.Username.Equals(patient.Username)))
            {
                throw new ArgumentException($"Doctor with username {patient.Username} already exist.");
            }
            //var currentDoctor = _mapper.Map<Doctor>(doctor);
            var formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime submissionDate = DateTime.ParseExact(formattedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            Doctor currentDoctor = new Doctor()
            {
                Password = patient.Password,
                Username = patient.Username,
                Fname = patient.Fname,
                Lname = patient.Lname,
                NationalId = patient.NationalId,
                ProfileStatus = patient.ProfileStatus,
                Address = patient.Address,
                Phone = patient.Phone,
                Education = doctor.Education,
                Experience = doctor.Experience,
                Sepcialzation = doctor.Sepcialzation,
                Description = doctor.Description,
                ProfilePicture = patient.ProfilePicture,
                DoctorStatus = 1,
                SubmissionDate = submissionDate,
                DateOfBirth = patient.DateOfBirth,

            };
            _context.Doctors.Add(currentDoctor);
            //_context.Doctors.Add(doctor1);

            await _context.SaveChangesAsync();

        }
        public async Task<DoctorResponseDTO> GetDoctorData(UserInformationDTO userInformation)
        {
            var doctor = _context.Doctors
                .Where(x => x.Id.Equals(userInformation.Id)).FirstOrDefault();
            var currentDoctor = _mapper.Map<DoctorResponseDTO>(doctor);

            return currentDoctor;
        }


        public async Task<DocAttacment> AddDocAttachment(DoctorFilesDTO docAttacment)
        {
            var newFile = _mapper.Map<DocAttacment>(docAttacment);


            _context.DocAttacments.Add(newFile);
            await _context.SaveChangesAsync();

            return newFile;



        }


        public async Task RateDoctor(int doc_Id, int stars)
        {

            var doctor = await _context.Doctors.FindAsync(doc_Id);

            if (doctor != null)
            {
                // Increase appointments count
                if (doctor.Appointments == null || doctor.RatingCount == null)
                {
                    doctor.Appointments = 0;
                    doctor.RatingCount = 0;

                }
                doctor.Appointments++;

                // Increase rating_count by adding stars
                doctor.RatingCount += stars;

                await _context.SaveChangesAsync();

                // Calculate the rate
                if (doctor.Appointments != 0)
                    doctor.Rate = doctor.RatingCount / doctor.Appointments;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }

        }


        public async Task UpdateAsync(UpdateDoctorDTO doctor)
        {
            var existingdoctor = _context.Doctors.Where(x => x.Id.Equals(doctor.Id)).FirstOrDefault();

            if (existingdoctor != null)
            {


                existingdoctor.Password = doctor.Password;
                existingdoctor.Username = doctor.Username;
                existingdoctor.Fname = doctor.Fname;
                existingdoctor.Lname = doctor.Lname;
                existingdoctor.NationalId = doctor.NationalId;
                existingdoctor.Address = doctor.Address;
                existingdoctor.ProfilePicture = doctor.ProfilePicture;
                existingdoctor.DateOfBirth = doctor.DateOfBirth;
                existingdoctor.Education = doctor.Education;
                existingdoctor.Experience = doctor.Experience;
                existingdoctor.Sepcialzation = doctor.Sepcialzation;
                existingdoctor.Description = doctor.Description;



                _context.Entry(existingdoctor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
        }

    }
}

