using datingAppBackend.Models;
using System;

namespace YourNamespace.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        // Foreign key to sender (User)
        public string SenderId { get; set; }
        public User Sender { get; set; }

        // Foreign key to receiver (User)
        public string ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}
