using AutoMapper;
using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AutoMapper
{
    public class PatientMapper :Profile
    {
        public PatientMapper()
        {
            CreateMap<PatientDTO, Patient>()
           .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus));
            CreateMap<Patient, PatientResponseDTO>();
            CreateMap<Doctor, DoctorResponseDTO>();
            CreateMap<Admin, AdminResponseDTO>();


            CreateMap<JoinOurTeamDTO, Doctor>();
            CreateMap<ServicesDTO, Service>();
            CreateMap<DoctorSchedualeDTO, TempDoctorSchedule>();


            CreateMap<QuickRegisterDTO, Report>();
            CreateMap<QuickRegisterDTO, Patient>();


            CreateMap<DoctorFilesDTO, DocAttacment>();



            CreateMap<QuickRegisterDTO, Patient>().ForMember(dest => dest.ProfileStatus, opt => opt.MapFrom(src => 1))
    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NationalId.ToString())).ForMember(fname => fname.Fname, fname => fname.MapFrom(src => "yourFirstName")).ForMember(lname => lname.Lname, lname => lname.MapFrom(src => "yourLastName")); 

        }
    }
}
