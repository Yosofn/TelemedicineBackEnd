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
    public class QuickRegister : IQuickRegister
    {
        private readonly TelemedicineContext _context;
        private readonly IMapper _patientmapper;

        public QuickRegister(TelemedicineContext context, IMapper patientMapper) {

            _context = context;
            _patientmapper = patientMapper;
        }
        async Task<AuthResponse> IQuickRegister.QuickRegisteration(QuickRegisterDTO quickregister)
        {
            var currentUser = _context.Patients
    .FirstOrDefault(patient => patient.NationalId == quickregister.NationalId);


            if (currentUser != null)
            {
                var currentReport = _patientmapper.Map<Report>(currentUser);
                _context.Reports.Add(currentReport);
                await _context.SaveChangesAsync();

                return new AuthResponse { Success = true, type = $" {currentUser.Username} already exists ..... we have uploaded the report successfully " };
            }
            else
            {
                var currentPatient = _patientmapper.Map<Patient>(quickregister);
                var currentReport = _patientmapper.Map<Report>(quickregister);
                _context.Patients.Add(currentPatient);
                _context.Reports.Add(currentReport);

                //it save the data but gives an exeption here ...
                await _context.SaveChangesAsync();
                    return new AuthResponse { Success = true, type = "This account have been registerded successfully .." };
                
            }
        }
        private Func<Patient, bool> FilterPatient(string username, long? nationalId)
        {
            return x => x.Username.Equals(username) && x.NationalId.Equals(nationalId);
        }

        //private Func<Doctor, bool> FilterDoctor(string username, long? nationalId)
        //{
        //    return x => x.Username.Equals(username) && x.NationalId.Equals(nationalId);
        //}
    }

 
}
