using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> GetByNationalIdAsync(UserInformationDTO userInformation);

        Task AddAsync(Patient patient);
        Task Register(PatientDTO patient);
        AuthResponse Registration(PatientDTO patient);

        AuthResponse UserLogin(UserLoginDTO patient);

        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    


    }
}
