using BLL.Interfaces;
using DAL.Context;
using DAL.DTOS.RequestDTO;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class MedicalDeviceRepository : IMedicalDeviceRepository

    {
        private readonly TelemedicineContext _context;

        public MedicalDeviceRepository(
            TelemedicineContext context
            ) {
        _context=context;
        
        }
        public async Task<MedicalDevice> GetDeviceData(UserInformationDTO userInformation)
        {
            var device = _context.MedicalDevices
                           .Where(x => x.DeviceNumber.Equals(userInformation.Id)).FirstOrDefault();

            return device;
        }
    }
}
