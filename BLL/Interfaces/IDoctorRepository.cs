using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDoctorRepository
    {
        Task JoinOurTeam(JoinOurTeamDTO doctor);
        Task<Doctor> GetDoctorData(UserInformationDTO userInformation);
         Task<DocAttacment> AddDocWorkHours(DoctorSchedualeDTO docAttacment);

         Task<DocAttacment> AddDocAttachment(DoctorFilesDTO docAttacment);


    }
}
