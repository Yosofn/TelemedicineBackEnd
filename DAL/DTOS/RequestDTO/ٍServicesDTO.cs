﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class ServicesDTO
    {
        [Required]
        [Column("service_price")]
        [StringLength(10)]
        [Unicode(false)]
        public string ServicePrice { get; set; }
        [Required]
        [Column("service_name")]
        [StringLength(100)]
        [Unicode(false)]
        public string ServiceName { get; set; }
        [Column("service_place")]
        public int ServicePlace { get; set; }
        [Column("discount", TypeName = "decimal(18, 0)")]
        public decimal? Discount { get; set; }
        [Column("service_type")]
        public int ServiceType { get; set; }
        [Column("admin_id")]
        public int AdminId { get; set; }
    }
}
