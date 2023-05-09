using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class UserInformationDTO
    {
        [Column("profile_status")]

        public int ProfileStatus { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
