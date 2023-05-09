using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class DoctorSchedualeDTO
    {

        [Column("start", TypeName = "datetime")]
        public DateTime? Start { get; set; }
        [Column("finish", TypeName = "datetime")]
        public DateTime? Finish { get; set; }
        [Column("doc_id")]
        public int? DocId { get; set; }

        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
