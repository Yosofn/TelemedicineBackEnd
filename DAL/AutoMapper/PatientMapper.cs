using AutoMapper;
using DAL.DTOS.RequestDTO;
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

            CreateMap<JoinOurTeamDTO, Doctor>();
            //CreateMap<DocAttacment, DocAttacment>();



            CreateMap<QuickRegisterDTO, Patient>().ForMember(dest => dest.ProfileStatus, opt => opt.MapFrom(src => 1))
    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NationalId.ToString())).ForMember(fname => fname.Fname, fname => fname.MapFrom(src => "yourFirstName")).ForMember(lname => lname.Lname, lname => lname.MapFrom(src => "yourLastName")); 

        }
    }
}
