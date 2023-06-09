﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Table("medical_device")]
    [Index("Username", Name = "username_UNIQUE", IsUnique = true)]
    public partial class MedicalDevice
    {
        public MedicalDevice()
        {
            Reports = new HashSet<Report>();
        }

        [Key]
        [Column("device_number")]
        public int DeviceNumber { get; set; }
        [Required]
        [Column("username")]
        [StringLength(45)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(45)]
        public string Password { get; set; }
        [Column("profileStatus")]
        public int? ProfileStatus { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string DeviceName { get; set; }

        [InverseProperty("DeviceNumberNavigation")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}