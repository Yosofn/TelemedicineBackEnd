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

        [Column("report", TypeName = "image")]
        public byte[] Report { get; set; }
        [Column("patient_Id")]
        public int? PatientId { get; set; }

        public int? doctorId { get; set; }

        [Column("device_number")]
        public int? DeviceNumber { get; set; }
    }
}
