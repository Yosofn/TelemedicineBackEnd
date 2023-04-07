﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Table("admin")]
    public partial class Admin
    {
        public Admin()
        {
            Appointments = new HashSet<Appointment>();
            Doctors = new HashSet<Doctor>();
            Services = new HashSet<Service>();
        }

        [Key]
        [Column("admin_id")]
        public int AdminId { get; set; }
        [Required]
        [Column("username")]
        [Unicode(false)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        [Unicode(false)]
        public string Password { get; set; }
        [Column("age")]
        public int? Age { get; set; }
        [Column("fname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Fname { get; set; }
        [Column("lname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Lname { get; set; }
        [Column("address")]
        [Unicode(false)]
        public string Address { get; set; }
        [Column("phone")]
        [StringLength(50)]
        [Unicode(false)]
        public string Phone { get; set; }
        [Column("gender")]
        [StringLength(6)]
        [Unicode(false)]
        public string Gender { get; set; }
        [Column("profile_picture")]
        [Unicode(false)]
        public string ProfilePicture { get; set; }
        [Column("profile_status")]
        public int ProfileStatus { get; set; }

        [InverseProperty("Admin")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<Service> Services { get; set; }
    }
}