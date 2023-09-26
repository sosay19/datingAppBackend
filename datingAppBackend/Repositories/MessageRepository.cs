using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Data; // Import your ApplicationDbContext and Message model
using YourNamespace.Models;

namespace YourNamespace.Repositories
{
    public class MessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }

        public Message GetMessageById(int messageId)
        {
            return _context.Messages.FirstOrDefault(message => message.Id == messageId);
        }

        public IEnumerable<Message> GetMessagesForUser(string userId)
        {
            return _context.Messages
                .Where(message => message.SenderId == userId || message.ReceiverId == userId)
                .ToList();
        }

        public void CreateMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void UpdateMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            _context.Entry(message).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMessage(int messageId)
        {
            var message = _context.Messages.FirstOrDefault(message => message.Id == messageId);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
        }
    }
}
