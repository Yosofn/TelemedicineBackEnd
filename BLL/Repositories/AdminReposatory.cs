using BLL.Interfaces;
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

        public AdminReposatory(TelemedicineContext context) {
        
        _context=context;
        }

        public ApprovedResponse ApproveDoctor(int doctorId, int  doctorStatus)
        {
            var doctor = _context.Doctors.Find(doctorId);

            //if (doctor == null)
            //{
            //    return notF;
            //}

            doctor.DoctorStatus = doctorStatus;


            _context.SaveChanges();

            if (doctor.DoctorStatus == 2)
            {
                doctor.ProfileStatus = 2;
                _context.SaveChanges();
                return new ApprovedResponse { Accepted = true };
            }

            return new ApprovedResponse { Accepted = false };
        }

        public async Task<Admin> GetAdminData(UserInformationDTO userInformation)
        {
            var admin = _context.Admins
               .Where(x => x.Id.Equals(userInformation.Id)).FirstOrDefault();

            return admin;
        }

        public IQueryable <Doctor> GetDoctorsStatus(int doctorStatus)
        {
          var UnApprovedDoctors =  _context.Doctors.Where(d => d.DoctorStatus == doctorStatus);

            return  UnApprovedDoctors;

        }
    }
}
