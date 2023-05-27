using BLL.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class BookingRepository :IBookingRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly TelemedicineContext _context;

        public BookingRepository(IDoctorRepository doctorRepository,TelemedicineContext context) {
        _doctorRepository=doctorRepository;
            _context=context;

        }

        public async Task<List<string>> GetAvailableDays(int doctorId)
        {
            var secheduals = await _context.TempDoctorSchedules
                      .Where(s => s.DoctorId == doctorId).ToListAsync();

            List<string> availableDays = new List<string>();


            foreach (var schedule in secheduals)
            {
                availableDays.Add(schedule.Day);
            }

            return availableDays;

        }
    }
}
