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

        public int Id { get; set; }
        [Column("education")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Education { get; set; }

        [Column("profile_picture", TypeName = "image")]
        public byte[]? ProfilePicture { get; set; }

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
    

    }
}
