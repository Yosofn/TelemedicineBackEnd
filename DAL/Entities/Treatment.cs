﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Table("treatment")]
    public partial class Treatment
    {
        [Key]
        [Column("treatment_Id")]
        public int TreatmentId { get; set; }
        [Column("treatment", TypeName = "image")]
        public byte[] Treatment1 { get; set; }
        [Column("patient_Id")]
        public int? PatientId { get; set; }
        [Column("record_Id")]
        public int? RecordId { get; set; }
        [Column("doc_Id")]
        public int? DocId { get; set; }

        [ForeignKey("DocId")]
        [InverseProperty("Treatments")]
        public virtual Doctor Doc { get; set; }
        [ForeignKey("PatientId")]
        [InverseProperty("Treatments")]
        public virtual Patient Patient { get; set; }
    }
}