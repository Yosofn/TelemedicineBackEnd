using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdminReposatory
    {
        public IQueryable  <Doctor> GetDoctorsStatus(int doctorstatus);

        public ApprovedResponse ApproveDoctor(ApproveDoctorDTO approveDoctor);
        public ApprovedResponse ApproveBooking(AppointmentDTO approveBooking);


        Task<AdminResponseDTO> GetAdminData(UserInformationDTO userInformation);

    }
}
