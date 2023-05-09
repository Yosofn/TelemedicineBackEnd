using DAL.DTOS.RequestDTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMedicalDeviceRepository
    {
        Task<MedicalDevice> GetDeviceData(UserInformationDTO userInformation);


    }
}
