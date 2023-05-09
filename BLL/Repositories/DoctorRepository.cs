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
        private readonly IMapper _patientMapper;

        public DoctorRepository(TelemedicineContext context, IMapper patientMapper)
        
        {
            _context = context;
            _patientMapper = patientMapper;

        }

        public async Task JoinOurTeam(JoinOurTeamDTO doctor)
        {
            if (_context.Doctors.Any(x => x.Username.Equals(doctor.Username)))
            {
                throw new ArgumentException($"Doctor with username {doctor.Username} already exist.");
            }

            var currentDoctor = _patientMapper.Map<Doctor>(doctor);

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

        public async Task<DocAttacment> AddDocWorkHours(DoctorSchedualeDTO docScheduale)
        {

            var newscheduale = _patientMapper.Map<DocAttacment>(docScheduale);

            _context.DocAttacments.Add(newscheduale);
            await _context.SaveChangesAsync();

            return newscheduale;
        }

        public async Task<DocAttacment> AddDocAttachment(DoctorFilesDTO docAttacment)
        {
            var newFile = _patientMapper.Map<DocAttacment>(docAttacment);


            _context.DocAttacments.Add(newFile);
           await _context.SaveChangesAsync();

            return newFile;



        }
    }
}
