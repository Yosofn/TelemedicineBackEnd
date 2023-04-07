﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Table("followup")]
    public partial class Followup
    {
        public Followup()
        {
            Appointments = new HashSet<Appointment>();
            Attachments = new HashSet<Attachment>();
            Messages = new HashSet<Message>();
        }

        [Key]
        [Column("followup_id")]
        public int FollowupId { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("expiry_date")]
        public DateTime ExpiryDate { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("doc_id")]
        public int DocId { get; set; }

        [ForeignKey("DocId")]
        [InverseProperty("Followups")]
        public virtual Doctor Doc { get; set; }
        [ForeignKey("PatientId")]
        [InverseProperty("Followups")]
        public virtual Patient Patient { get; set; }
        [InverseProperty("Followup")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [InverseProperty("Followup")]
        public virtual ICollection<Attachment> Attachments { get; set; }
        [InverseProperty("Followup")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}