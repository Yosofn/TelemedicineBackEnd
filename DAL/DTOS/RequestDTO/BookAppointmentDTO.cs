using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.DTOS.RequestDTO
{
    public class BookAppointmentDTO
    {

        [Column("appointment_date", TypeName = "datetime")]
        public DateTime AppointmentDate { get; set; }
     
        [Column("reservation_date", TypeName = "datetime")]
        public DateTime ReservationDate { get; set; }
        [Column("start")]
        public TimeSpan? Start { get; set; }
        [Required]
        [Column("place")]
        [StringLength(50)]
        public string Place { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("booking_receipt")]
        public string BookingReceipt { get; set; }
        [Column("scheduale_Id")]
        public int? SchedualeId { get; set; }
        [Column("doc_id")]
        public int? DocId { get; set; }
        [Column("end_time")]
        public TimeSpan? EndTime { get; set; }
  
    }
}
