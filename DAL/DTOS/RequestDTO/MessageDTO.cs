using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.RequestDTO
{
    public class MessageDTO
    {

        [Required]
        [Column("content", TypeName = "text")]
        public string Content { get; set; }
   

        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }


        public int? Type { get; set; }

    }
}
