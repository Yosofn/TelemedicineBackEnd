using BLL.Interfaces;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly TelemedicineContext _context;

        public BookingRepository(IDoctorRepository doctorRepository, TelemedicineContext context) {
            _doctorRepository = doctorRepository;
            _context = context;

        }

        public async Task<List<string>> GetAvailableDays(int doctorId)
        {
            var schedules = await _context.DoctorSchedules
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();

            List<string> availableDays = schedules.Select(s => s.Date?.ToString("yyyy-MM-dd")).ToList();

            return availableDays;
        }


        public async Task<List<TimeSpan?>> GetAvailableAppointments(int scheduleId)
        {
            // Retrieve the schedule from the DoctorSchedules table by scheduleId
            var schedule =  _context.DoctorSchedules.FirstOrDefault(s => s.ScheduleId == scheduleId);
            if (schedule == null)
            {
                // Handle the case where the schedule doesn't exist
                return null;
            }

            // Calculate the start and end times based on the schedule
            TimeSpan? startTime = schedule.StartTime;
            TimeSpan? endTime = schedule.EndTime ;

            if (startTime == null || endTime == null)
            {
                // Handle the case where startTime or endTime is null
                return  null;
            }

            // Loop from startTime to endTime and add appointments to the allAppointments list
            List<TimeSpan?> allAppointments = new List<TimeSpan?>();
            TimeSpan? currentAppointmentTime = startTime;
            double durationInMinutes =  (double)schedule.Duration;
            allAppointments.Add(startTime);

            while (currentAppointmentTime.Value.Add(TimeSpan.FromMinutes(durationInMinutes)) <= endTime.Value)
            {
                allAppointments.Add(currentAppointmentTime);
                currentAppointmentTime = currentAppointmentTime.Value.Add(TimeSpan.FromMinutes(durationInMinutes));
            }

            // Retrieve booked appointments from the Appointments table by scheduleId and status
            var bookedAppointments = _context.Appointments
                .Where(a => a.SchedualeId == scheduleId && (a.Status == 1 || a.Status == 2))
                .Select(a => a.Start)
                .ToList();

            // Remove booked appointments from allAppointments
            allAppointments =  allAppointments.Except(bookedAppointments).ToList();

            return allAppointments;
        }
    }
}
