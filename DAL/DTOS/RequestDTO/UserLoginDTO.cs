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
    public class UserLoginDTO
    {

        [Required]
        public string? Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Password { get; set; }
    }
}
