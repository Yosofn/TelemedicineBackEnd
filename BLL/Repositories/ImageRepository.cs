using BLL.Interfaces;
using DAL.AutoMapper;
using DAL.Context;
using DAL.DTOS.RequestDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class ImageRepository:IImageRepository
    {
        private readonly TelemedicineContext _context;

        public ImageRepository(TelemedicineContext context
             
            ) {

            _context = context;      
                }
        public async Task<Byte[]> SetImage(int Id, IFormFile image,int profileStatus)
        {
            Stream stream = image.OpenReadStream();
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

            if (profileStatus == 1)
            {
                _context.Patients.FirstOrDefault(a => a.Id == Id).ProfilePicture = bytes;
                _context.SaveChanges();
            }
            else
            {
                _context.Doctors.FirstOrDefault(a => a.Id == Id).ProfilePicture = bytes;
                _context.SaveChanges();
            }
            return bytes;
        }

        public async Task<Byte[]> GetImage(int UserId, int profileStatus)
        {
            if (profileStatus == 1)
            {
                var user = await _context.Patients.FirstOrDefaultAsync(a => a.Id == UserId);
                return user?.ProfilePicture;

            }
            else
            {
                var user = await _context.Doctors.FirstOrDefaultAsync(a => a.Id == UserId);
                return user?.ProfilePicture;
            }
            

        }

        public async Task<byte[]> SetAttachment(int? Id, IFormFile image,string type)
        {
            Stream stream = image.OpenReadStream();
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

            DocAttacment DocAttacment = new DocAttacment()
            {  Id=0,
               Type = type,
               DocId = Id,
                File = bytes
            };
            //var currentPatient = _mapper.Map<DocAttacment>(addfile);

            _context.DocAttacments.Add(DocAttacment);
            _context.SaveChanges();

            return bytes;

        }
    }
}
