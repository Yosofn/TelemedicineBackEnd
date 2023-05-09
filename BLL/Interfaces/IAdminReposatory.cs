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

        public ApprovedResponse ApproveDoctor(int doctorId, int doctorstatus);

        Task<Admin> GetAdminData(UserInformationDTO userInformation);

    }
}
