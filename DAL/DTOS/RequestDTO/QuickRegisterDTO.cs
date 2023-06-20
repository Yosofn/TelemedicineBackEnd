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
    public class QuickRegisterDTO
    {
        [Column("national_id")]
        public long? NationalId { get; set; }
        [Required]
        [Column("username")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Username { get; set; }

        [Column("phone")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Phone { get; set; }

        [Column("report", TypeName = "image")]
        public byte[] Report { get; set; }

    }
}
