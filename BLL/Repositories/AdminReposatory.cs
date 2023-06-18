using AutoMapper;
using BLL.Interfaces;
using DAL.AutoMapper;
using DAL.Context;
using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class AdminReposatory : IAdminReposatory
    {
        private readonly TelemedicineContext _context;
        private readonly IMapper _mapper;

        public AdminReposatory(TelemedicineContext context, IMapper patientMapper) {
        
        _context=context;
        _mapper = patientMapper;


        }

        public ApprovedResponse ApproveDoctor(ApproveDoctorDTO approveDoctor)
        {
            var doctor = _context.Doctors.Find(approveDoctor.DocId);

            doctor.AdminId= approveDoctor.AdminId;
            doctor.DoctorStatus = approveDoctor.DoctorStatus;
            _context.SaveChanges();

           if (doctor.DoctorStatus == 2)
            {
                doctor.ProfileStatus = 2;
                _context.SaveChanges();
                return new ApprovedResponse { Accepted = true };
            }

            return new ApprovedResponse { Accepted = false };
        }



        public ApprovedResponse ApproveBooking(AppointmentDTO approvebooking)
        {
            var appointment = _context.Appointments.Find(approvebooking.Id);

            appointment.AdminId = approvebooking.AdminId;
            appointment.Status = approvebooking.Status;
            _context.SaveChanges();

      
                return new ApprovedResponse { Accepted = true };
 
        }

        public async Task<AdminResponseDTO> GetAdminData(UserInformationDTO userInformation)
        {
            var admin = _context.Admins
               .Where(x => x.Id.Equals(userInformation.Id)).FirstOrDefault();
            var currentAdmin = _mapper.Map<AdminResponseDTO>(admin);

            return currentAdmin;
        }

        public IQueryable <Doctor> GetDoctorsStatus(int doctorStatus)
        {
          var UnApprovedDoctors =  _context.Doctors.Where(d => d.DoctorStatus == doctorStatus);

            return  UnApprovedDoctors;

        }
    }
}
