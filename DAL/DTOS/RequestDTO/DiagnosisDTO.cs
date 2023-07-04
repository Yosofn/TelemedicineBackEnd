﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class DiagnosisDTO
    {

        [Column("diagnosis", TypeName = "image")]
        public byte[] Diagnosis1 { get; set; }
        [Column("patient_Id")]
        public int? PatientId { get; set; }

        [Column("doc_Id")]
        public int? DocId { get; set; }
    }
}
