﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    public partial class Report
    {
        [Key]
        [Column("report_id")]
        public int ReportId { get; set; }
        [Column("report", TypeName = "image")]
        public byte[] Report1 { get; set; }
        [Column("patient_Id")]
        public int? PatientId { get; set; }
        [Column("record_Id")]
        public int? RecordId { get; set; }
        [Column("device_number")]
        public int? DeviceNumber { get; set; }
        [Column("doc_id")]
        public int? DocId { get; set; }

        [ForeignKey("DeviceNumber")]
        [InverseProperty("Reports")]
        public virtual MedicalDevice DeviceNumberNavigation { get; set; }
        [ForeignKey("DocId")]
        [InverseProperty("Reports")]
        public virtual Doctor Doc { get; set; }
        [ForeignKey("PatientId")]
        [InverseProperty("Reports")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("RecordId")]
        [InverseProperty("Reports")]
        public virtual MedicalRecord Record { get; set; }
    }
}