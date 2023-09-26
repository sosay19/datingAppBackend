namespace datingAppBackend.DTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        // Add more message-related properties as needed

        public MessageDto()
        {
            // Default constructor
        }

        public MessageDto(Guid id, Guid senderId, Guid receiverId, string content, DateTime sentAt)
        {
            Id = id;
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            SentAt = sentAt;
        }
    }
}
