using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IImageRepository
    {
        public Task<Byte[]> SetImage(int Id, IFormFile image,int profileStatus);
        public Task<Byte[]> SetAttachment(int? Id, IFormFile image,string type);

        public Task<Byte[]> GetImage(int UserId,int  profileStatus);
    }
}
