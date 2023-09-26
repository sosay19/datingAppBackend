using System;
using System.Collections.Generic;
using YourNamespace.Data; // Import your ApplicationDbContext and Message model
using YourNamespace.Models;
using YourNamespace.Repositories; // Import your MessageRepository

namespace YourNamespace.Services
{
    public class ChatService
    {
        private readonly MessageRepository _messageRepository;

        public ChatService(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetChatMessages(string senderId, string receiverId)
        {
            // Retrieve chat messages between two users based on their IDs
            return _messageRepository.GetMessagesBetweenUsers(senderId, receiverId);
        }

        public void SendMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            // Save the message to the database
            _messageRepository.CreateMessage(message);

            // You can implement real-time communication to notify the recipient of the new message
            // This may involve technologies like SignalR for real-time updates
        }

        // Other chat-related methods can be added as needed, such as creating chat rooms or managing conversations
    }
}
