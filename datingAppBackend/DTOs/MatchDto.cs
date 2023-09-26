namespace datingAppBackend.DTOs
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
        public DateTime MatchedDate { get; set; }
        // Add more match-related properties as needed

        public MatchDto()
        {
            // Default constructor
        }

        public MatchDto(Guid id, Guid user1Id, Guid user2Id, DateTime matchedDate)
        {
            Id = id;
            User1Id = user1Id;
            User2Id = user2Id;
            MatchedDate = matchedDate;
        }
    }
}
