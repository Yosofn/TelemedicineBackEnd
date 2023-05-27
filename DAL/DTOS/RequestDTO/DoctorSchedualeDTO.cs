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
    public class DoctorSchedualeDTO
    {
      
        public int? DoctorId { get; set; }
        [Column("day")]
        [StringLength(10)]
        [Unicode(false)]
        public string Day { get; set; }
        [Column("start_time")]
        public TimeSpan? StartTime { get; set; }
        [Column("end_time")]
        public TimeSpan? EndTime { get; set; }
        [Column("price", TypeName = "decimal(10, 2)")]
        public decimal? Price { get; set; }
        [Column("timeslot")]
        public int? Timeslot { get; set; }
        [Column("place")]
        public string Place { get; set; }
    }
}
