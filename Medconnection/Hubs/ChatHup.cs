using DAL.Context;
using DAL.DTOS.RequestDTO;
using DAL.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace Medconnection.Hubs
{


    public class ChatHub : Hub
    {
        private readonly TelemedicineContext _context;

        public ChatHub(TelemedicineContext context)
        {
            _context = context;

        }


        //public async Task SendMessage(int patientId, int doctorId, string message)
        //{
        //    DateTime expiryDate = GetExpiryDateFromDatabase(patientId, doctorId);
        //    int status = DateTime.Now > expiryDate ? 0 : 1;

        //    if (status == 1)
        //    {
        //        int followUpId = GetFollowUpIdFromDatabase(patientId, doctorId);
        //        SaveMessageToDatabase(followUpId, message, DateTime.Now);

        //        await Clients.Group(followUpId.ToString()).SendAsync("ReceiveMessage", message, DateTime.Now);
        //    }
        //}


        public async Task SendMessage(MessageDTO message)
        {

            Message newMessage = new Message
            {
                Content = message.Content,
                Date = DateTime.Now,
                SenderId = message.SenderId,
                ReceiverId = message.ReceiverId,
                Type = message.Type,
            };

            await Clients.All.SendAsync("ReceiveMessage", newMessage.ReceiverId, newMessage.Content);

            // Add the new message to the context

            _context.Messages.Add(newMessage);
            // Save changes to the database

            await _context.SaveChangesAsync();
        }
        public async Task JoinGroup(int patientId, int doctorId)
        {
            int followUpId = GetFollowUpIdFromDatabase(patientId, doctorId);
            await Groups.AddToGroupAsync(Context.ConnectionId, followUpId.ToString());
        }

        public async Task LeaveGroup(int patientId, int doctorId)
        {
            int followUpId = GetFollowUpIdFromDatabase(patientId, doctorId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, followUpId.ToString());
        }

        public async Task<IEnumerable<string>> GetAllMessages(int patientId, int doctorId)
        {
            int followUpId = GetFollowUpIdFromDatabase(patientId, doctorId);
            return await GetMessagesFromDatabase(followUpId);
        }

        public override async Task OnConnectedAsync()
        {
            // Additional logic for handling connections
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Additional logic for handling disconnections
            await base.OnDisconnectedAsync(exception);
        }

        private DateTime GetExpiryDateFromDatabase(int patientId, int doctorId)
        {
            // Retrieve expiry date from the database based on patientId and doctorId
            // Implement your database access logic here
            throw new NotImplementedException();
        }

        private int GetFollowUpIdFromDatabase(int patientId, int doctorId)
        {
            // Retrieve follow-up ID from the database based on patientId and doctorId
            // Implement your database access logic here
            throw new NotImplementedException();
        }

        private void SaveMessageToDatabase(int followUpId, string message, DateTime date)
        {
            // Save the message to the database
            // Implement your database access logic here
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<string>> GetMessagesFromDatabase(int followUpId)
        {
            // Retrieve all messages from the database based on followUpId
            // Implement your database access logic here
            throw new NotImplementedException();
        }
    }

}

