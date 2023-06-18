using BLL.Interfaces;
using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly IPatientRepository _pateintrepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IQuickRegister _quickRegister;

        public Authentication(IPatientRepository patientRepository,IDoctorRepository doctorRepository,IQuickRegister quickRegister) {
            _pateintrepository= patientRepository;
            _doctorRepository = doctorRepository;
            _quickRegister = quickRegister;
        }

        [HttpPost("Registration")]
        public IActionResult Registration(PatientDTO patientDTO)
        {
            var Authresult= _pateintrepository.Registration(patientDTO);

            if (Authresult.Success)
            {
                return Ok(Authresult);
            }
            else
            {
                return CreatedAtAction("GetPatient", patientDTO);

            }

        }

        [HttpPost("JoinOurTeam")]
        public async Task <ActionResult<AuthResponse>>  JoinOurTeam(JoinOurTeamDTO doctorDTo)
        {
            await _doctorRepository.JoinOurTeam(doctorDTo);
            return Ok();

        }


        [HttpPost("Login")]

        public IActionResult Login(UserLoginDTO patientDTO)
        {
            var Authresult = _pateintrepository.UserLogin(patientDTO);

            if (Authresult.Success)
            {
                return Ok(Authresult);
            }
            else
            {
              return BadRequest(Authresult);
            }

        }

        [HttpPost("QuickRegister")]


        public IActionResult QuickRegister(QuickRegisterDTO quickRegister)
        {
            var Authresult = _quickRegister.QuickRegisteration(quickRegister);

            return Ok(Authresult);
        }

    }




}

