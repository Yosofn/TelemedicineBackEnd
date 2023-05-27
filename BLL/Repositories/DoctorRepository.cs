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
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class DoctorRepository :IDoctorRepository
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
            if (_context.Doctors.Any(x => x.Username.Equals(doctor.Username)))
            {
                throw new ArgumentException($"Doctor with username {doctor.Username} already exist.");
            }
            var currentDoctor = _mapper.Map<Doctor>(doctor);

            //Doctor doctor1 = new Doctor()
            //{
            //    Password = currentDoctor.Password,
            //    Username = currentDoctor.Username,
            //    Fname = currentDoctor.Username,
            //    Lname = currentDoctor.Username,
            //    NationalId = currentDoctor.NationalId,
            //    ProfileStatus = currentDoctor.ProfileStatus,
            //    Address = currentDoctor.Address,
            //    Phone = currentDoctor.Phone,
            //    Education = currentDoctor.Education,
            //    Experience = currentDoctor.Experience,
            //    Sepcialzation = currentDoctor.Sepcialzation,
            //    Description = currentDoctor.Description,
            //    DoctorStatus = currentDoctor.DoctorStatus,
            //    SubmissionDate = currentDoctor.SubmissionDate,
            //    AdminId = currentDoctor.AdminId,

            //};
            _context.Doctors.Add(currentDoctor);
            //_context.Doctors.Add(doctor1);

            await _context.SaveChangesAsync();

        }
        public async Task<Doctor> GetDoctorData(UserInformationDTO userInformation)
        {
            var doctor =   _context.Doctors
                .Where(x => x.Id.Equals(userInformation.Id)).FirstOrDefault();

            return  doctor;
        }


        public async Task<DocAttacment> AddDocAttachment(DoctorFilesDTO docAttacment)
        {
            var newFile = _mapper.Map<DocAttacment>(docAttacment);


            _context.DocAttacments.Add(newFile);
           await _context.SaveChangesAsync();

            return newFile;



        }


         public async Task RateDoctor(int doc_Id,int stars)
        {

            var doctor = await _context.Doctors.FindAsync(doc_Id);

            if (doctor != null)
            {
                // Increase appointments count
                if (doctor.Appointments ==null || doctor.RatingCount == null)
                {
                    doctor.Appointments = 0;
                    doctor.RatingCount=0;

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
    }
}
