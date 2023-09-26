using datingAppBackend.DTOs;
using datingAppBackend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace datingAppBackend.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        // Add more user-related properties as needed

        public UserDto()
        {
            // Default constructor
        }

        public UserDto(Guid id, string username, string email, string firstName, string lastName, DateTime birthDate)
        {
            Id = id;
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }

}
