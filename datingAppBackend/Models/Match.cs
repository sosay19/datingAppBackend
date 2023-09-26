using datingAppBackend.Models;
using System;

namespace YourNamespace.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchedAt { get; set; }

        // Foreign key to User (User A)
        public string UserAId { get; set; }
        public User UserA { get; set; }

        // Foreign key to User (User B)
        public string UserBId { get; set; }
        public User UserB { get; set; }
    }
}
