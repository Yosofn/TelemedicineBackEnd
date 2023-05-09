using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS.ResponseDTO
{
    public class AuthResponse
    {
        public Boolean Success { get; set; }



        public string? Token { get; set; }

        public string? type    {get;set;}

    }
}
