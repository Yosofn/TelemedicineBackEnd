
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.DTOS.ResponseDTO
{
    public class PatientResponseDTO
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("national_id")]
        public long? NationalId { get; set; }
        [Required]
        [Column("username")]
        [StringLength(50)]
        [Unicode(false)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        [Unicode(false)]
        public string Password { get; set; }
        [Column("age")]
        public int? Age { get; set; }
        [Column("address")]
        [StringLength(100)]
        [Unicode(false)]
        public string Address { get; set; }
        [Required]
        [Column("fname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Fname { get; set; }
        [Required]
        [Column("lname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Lname { get; set; }
        [Column("height")]
        public double? Height { get; set; }
        [Column("weight")]
        public double? Weight { get; set; }
        [Column("job")]
        [StringLength(50)]
        [Unicode(false)]
        public string Job { get; set; }
        [Column("phone")]
        [StringLength(50)]
        [Unicode(false)]
        public string Phone { get; set; }
        [Column("profile_status")]
        public int ProfileStatus { get; set; }
        [Column("gender")]
        [StringLength(6)]
        [Unicode(false)]
        public string Gender { get; set; }
        [Column("marital_status")]
        [StringLength(10)]
        [Unicode(false)]
        public string MaritalStatus { get; set; }

     

    }
}
