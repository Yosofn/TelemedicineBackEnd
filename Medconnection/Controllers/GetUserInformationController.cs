using AutoMapper;
using BLL.Interfaces;
using DAL.DTOS.RequestDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : Controller
    {
        private readonly IPatientRepository _pateintrepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly IAdminReposatory _adminRepository;
        private readonly IMedicalDeviceRepository _medicalDevice;

        public UserInformationController(IPatientRepository patientRepository, IDoctorRepository doctorRepository, IMapper mapper,IAdminReposatory adminRepository,IMedicalDeviceRepository medicalDevice)
        {
            _pateintrepository = patientRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _adminRepository= adminRepository;
            _medicalDevice= medicalDevice;

        }

        [HttpPost("GetUserInformation")]

        public async Task<IActionResult> GetUserInformation(UserInformationDTO userInformation)
        {
            try
            {
                switch (userInformation.ProfileStatus)
                {
                    case 1:
                        // Patient
                        var patient = _pateintrepository.GetByNationalIdAsync(userInformation);
                        if (patient == null)
                        {
                            return NotFound();
                        }
                        return Ok(patient);
                    case 2:
                        // Doctor
                        var doctor = _doctorRepository.GetDoctorData(userInformation);
                        if (doctor == null)
                        {
                            return NotFound();
                        }
                        return Ok(doctor);
                        case 3:
                        var admin = _adminRepository.GetAdminData(userInformation);
                        if (admin == null)
                        {
                            return NotFound();
                        }
                        return Ok(admin);
                        case 4:
                        var device = _medicalDevice.GetDeviceData(userInformation);
                        if (device == null)
                        {
                            return NotFound();
                        }
                        return Ok(device);


                    default:
                        return BadRequest("Invalid Profile Status");
                }
            }
            catch 
            {
                // Log the exception here
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }


        }
    }
}
