using BLL.Interfaces;
using DAL.Context;
using DAL.DTOS.RequestDTO;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Medconnection.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly TelemedicineContext _context;

        public BookingController(IBookingRepository bookingRepository,TelemedicineContext context)

        {
            _bookingRepository= bookingRepository;
            _context= context;

        }

        [HttpPost("GetAvailableDays")]
        public async Task<ActionResult<List<string>>>GetAvailableDays(int DoctorId)
        {
            List<string> availabledates = await _bookingRepository.GetAvailableDays(DoctorId);

            if (availabledates != null)
            {
                return Ok(availabledates);
            }

            return NotFound();
        }


        [HttpPost("GetAppointments")]
        public async Task<ActionResult<List<TimeSpan?>>> GetAppointments(int scheduleId)
        {
            var availableAppointments = await _bookingRepository.GetAvailableAppointments(scheduleId);

            return Ok(availableAppointments);
        }



        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(BookAppointmentDTO appointment)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'TelemedicineContext.Appointments'  is null.");
            }
            var doctor = await _context.Doctors.FindAsync(appointment.DocId);
            var patient = await _context.Patients.FindAsync(appointment.PatientId);
            var scheduale = await _context.DoctorSchedules.FindAsync(appointment.SchedualeId);


            Appointment newAppointment = new Appointment()
            {
                PatientName= patient?.Fname,
                DoctorName= doctor?.Fname,
                Price= (int?)scheduale?.Price,
                AppointmentDate = (DateTime)(scheduale?.Date),
                ReservationDate = DateTime.Now,
                Start = appointment.Start,
                EndTime = appointment.EndTime,
                Place = scheduale?.Place,
                Status = appointment.Status,
                BookingReceipt = appointment.BookingReceipt,
                SchedualeId = appointment.SchedualeId,
                DocId = appointment.DocId,
                PatientPhoto = patient?.ProfilePicture,
                DoctorPhoto = doctor?.ProfilePicture,
                PatientId= appointment.PatientId
                
           };

            _context.Appointments.Add(newAppointment);
            await _context.SaveChangesAsync();

            return Ok(newAppointment);
        }
    }
}
