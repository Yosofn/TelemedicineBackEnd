﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Table("medical_record")]
    public partial class MedicalRecord
    {
        public MedicalRecord()
        {
            DeviceReadings = new HashSet<DeviceReading>();
            DocConclusions = new HashSet<DocConclusion>();
            TestsResults = new HashSet<TestsResult>();
        }

        [Key]
        [Column("record_id")]
        public int RecordId { get; set; }
        [Column("reports", TypeName = "text")]
        public string Reports { get; set; }
        [Column("diagnosis", TypeName = "text")]
        public string Diagnosis { get; set; }
        [Column("treatments", TypeName = "text")]
        public string Treatments { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("expiry_date")]
        public DateTime ExpiryDate { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("MedicalRecords")]
        public virtual Patient Patient { get; set; }
        [InverseProperty("Record")]
        public virtual ICollection<DeviceReading> DeviceReadings { get; set; }
        [InverseProperty("Record")]
        public virtual ICollection<DocConclusion> DocConclusions { get; set; }
        [InverseProperty("Record")]
        public virtual ICollection<TestsResult> TestsResults { get; set; }
    }
}