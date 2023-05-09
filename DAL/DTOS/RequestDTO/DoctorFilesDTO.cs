using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class DoctorFilesDTO
    {
        [Column("type")]
        [StringLength(50)]
        public string? Type { get; set; }

        [Column("doc_id")]
        public int? DocId { get; set; }
        [Column("file", TypeName = "image")]
        public byte[]? File { get; set; }
    }
}
