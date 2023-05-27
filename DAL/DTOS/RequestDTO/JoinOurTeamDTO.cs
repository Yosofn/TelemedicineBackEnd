using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class JoinOurTeamDTO
    {

        [Column("national_id")]
        public long? NationalId { get; set; }
        [Required]
        [Column("username")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("address")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Address { get; set; }
        [Column("phone")]
        [StringLength(50)]
        [Unicode(false)]
        public string Phone { get; set; }
        [Required]
        [Column("fname")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Fname { get; set; }
        [Required]
        [Column("lname")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Lname { get; set; }
        [Column("education")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Education { get; set; }

        [Column("profile_picture", TypeName = "image")]
        public byte[]? ProfilePicture { get; set; }

        [Column("profile_status")]
        public int ProfileStatus { get; set; }
        [Required]
        [Column("experience", TypeName = "text")]
        public string? Experience { get; set; }
        [Required]
        [Column("sepcialzation")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Sepcialzation { get; set; }
   
        [Required]
        [Column("description", TypeName = "text")]
        public string? Description { get; set; }
        [Column("doctor_status")]
        public int DoctorStatus { get; set; }

        [Column("submission_date")]
        public DateTime? SubmissionDate { get; set; }
    }
}
