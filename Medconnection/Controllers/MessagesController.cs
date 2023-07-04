using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.SignalR;
using Medconnection.Hubs;
using DAL.DTOS.RequestDTO;

namespace Medconnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly TelemedicineContext _context;

        private readonly IHubContext<ChatHub> _hubContext;

        public MessagesController(TelemedicineContext context, IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
            _context = context;
        }
        [HttpPost("SendMessage")]

        public async Task<IActionResult> SendMessage(MessageDTO message)
        {
            // Process and validate the message
            Message newMessage = new Message
            {
                Content= message.Content,
                Date = DateTime.Now,
                SenderId=message.SenderId,
                ReceiverId=message.ReceiverId,
                Type=message.Type,

            };
            // Add the new message to the context

            _context.Messages.Add(newMessage);
            // Save changes to the database

            await _context.SaveChangesAsync();
            // Trigger the SendMessage method in the SignalR Hub

            await _hubContext.Clients.All.SendAsync("SendMessage", newMessage.Content, newMessage.SenderId);

            return Ok();
        }


        [HttpPost("GetMessages")]
        public async Task<IActionResult> GetMessages(AllMessagesDTO dto)
        {
            // Validate the DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve messages from the database based on the provided IDs
            var messages = await _context.Messages
                .Where(m => m.SenderId == dto.PatientId || m.ReceiverId == dto.PatientId)
                .Where(m => m.SenderId == dto.DoctorId || m.ReceiverId == dto.DoctorId)
                .ToListAsync();

            return Ok(messages);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }
            return await _context.Messages.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
          if (_context.Messages == null)
          {
              return Problem("Entity set 'TelemedicineContext.Messages'  is null.");
          }
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.MessageId }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return (_context.Messages?.Any(e => e.MessageId == id)).GetValueOrDefault();
        }
    }
}
