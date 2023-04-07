﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Table("doc_attacment")]
    [Index("DocId", Name = "doctors has attachment_idx")]
    public partial class DocAttacment
    {
        [Key]
        [Column("attach_id")]
        public int AttachId { get; set; }
        [Column("attachments")]
        [StringLength(45)]
        public string Attachments { get; set; }
        [Required]
        [Column("type")]
        [StringLength(20)]
        public string Type { get; set; }
        [Required]
        [Column("path")]
        public string Path { get; set; }
        [Column("working_hours")]
        public DateTime WorkingHours { get; set; }
        [Column("doc_id")]
        public int? DocId { get; set; }

        [ForeignKey("DocId")]
        [InverseProperty("DocAttacments")]
        public virtual Doctor Doc { get; set; }
    }
}