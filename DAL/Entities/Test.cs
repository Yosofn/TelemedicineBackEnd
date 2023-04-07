﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Table("test")]
    public partial class Test
    {
        public Test()
        {
            TestAttachments = new HashSet<TestAttachment>();
            TestsResults = new HashSet<TestsResult>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("result")]
        [StringLength(100)]
        [Unicode(false)]
        public string Result { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("test_date", TypeName = "datetime")]
        public DateTime TestDate { get; set; }
        [Required]
        [Column("test_price")]
        [StringLength(10)]
        [Unicode(false)]
        public string TestPrice { get; set; }
        [Column("reservation_date", TypeName = "datetime")]
        public DateTime ReservationDate { get; set; }
        [Column("service_id")]
        public int ServiceId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("Tests")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("ServiceId")]
        [InverseProperty("Tests")]
        public virtual Service Service { get; set; }
        [InverseProperty("Test")]
        public virtual ICollection<TestAttachment> TestAttachments { get; set; }
        [InverseProperty("Test")]
        public virtual ICollection<TestsResult> TestsResults { get; set; }
    }
}