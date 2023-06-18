using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.ResponseDTO
{
    public class AdminResponseDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        [Unicode(false)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        [Unicode(false)]
        public string Password { get; set; }
        [Column("age")]
        public int? Age { get; set; }
        [Column("fname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Fname { get; set; }
        [Column("lname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Lname { get; set; }
        [Column("address")]
        [Unicode(false)]
        public string Address { get; set; }
        [Column("phone")]
        [StringLength(50)]
        [Unicode(false)]
        public string Phone { get; set; }
        [Column("gender")]
        [StringLength(6)]
        [Unicode(false)]
        public string Gender { get; set; }

        [Column("profile_status")]
        public int ProfileStatus { get; set; }
        [Column("national_id")]
        public long? NationalId { get; set; }
    }
}
