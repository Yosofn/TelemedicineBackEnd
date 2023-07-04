using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class AllMessagesDTO
    {
        [Required]
        public int PatientId { get; set; }
        [Required]

        public int DoctorId { get; set; }

    }
}
