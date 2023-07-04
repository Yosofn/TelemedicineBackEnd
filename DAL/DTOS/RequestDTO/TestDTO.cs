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
    public class TestDTO
    {

  
        [Column("type")]
        public int Type { get; set; }
        [Column("test_date", TypeName = "date")]
        public DateTime? TestDate { get; set; }
        [Required]
        [Column("test_price")]
        [StringLength(10)]
        [Unicode(false)]
        public string TestPrice { get; set; }
        [Column("service_id")]
        public int ServiceId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("time")]
        public TimeSpan? Time { get; set; }
        [Column("test_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string TestName { get; set; }
    }
}
