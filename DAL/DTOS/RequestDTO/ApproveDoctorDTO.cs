using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class ApproveDoctorDTO
    {
        [Required]
        [Column("username")]
        [StringLength(50)]
        [Unicode(false)]
        public string Username { get; set; }

        [Column("doc_id")]
        public int? DocId { get; set; }

        [Column("doctor_status")]
        public int DoctorStatus { get; set; }

        [Column("admin_id")]
        public int AdminId { get; set; }
    }
}
