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
    public class UpdateDoctorDTO
    {
        [Key]
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
        [StringLength(50)]
        [Unicode(false)]
        public string Password { get; set; }
        [Column("address")]
        [StringLength(50)]
        [Unicode(false)]
        public string Address { get; set; }
        [Column("phone")]
        [StringLength(20)]
        [Unicode(false)]
        public string Phone { get; set; }
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
        [Column("education")]
        [StringLength(100)]
        [Unicode(false)]
        public string Education { get; set; }

        [Column("experience", TypeName = "text")]
        public string Experience { get; set; }
        [Column("sepcialzation")]
        [StringLength(50)]
        [Unicode(false)]
        public string Sepcialzation { get; set; }

        [Column("description", TypeName = "text")]
        public string Description { get; set; }

        [Column("profile_picture", TypeName = "image")]
        public byte[] ProfilePicture { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }



    }
}
