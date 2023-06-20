using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class ReportDTO
    {
        [Key]
        [Column("report_Id")]
        public int ReportId { get; set; }
        [Column("report", TypeName = "image")]
        public byte[] Report { get; set; }
        [Column("patient_Id")]
        public int? PatientId { get; set; }
        [Column("record_Id")]
        public int? RecordId { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("Reports")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("RecordId")]
        [InverseProperty("Reports")]
        public virtual MedicalRecord Record { get; set; }

    }
}
