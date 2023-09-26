using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity; // Import Identity-related classes if using ASP.NET Identity

namespace YourNamespace.Models
{
    public class User : IdentityUser
    {
        // Additional user profile properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfileImage { get; set; }

        // Navigation property to access user's messages
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }

        // Navigation property to access user's matches
        public ICollection<Match> Matches { get; set; }
    }
}
