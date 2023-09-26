using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using YourNamespace.Services; // Import your user service
using YourNamespace.Models; // Import your user model
using datingAppBackend.Services;

namespace YourNamespace.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize] // Require authentication for user operations
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous] // Allow anonymous access for registration
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationDto registrationDto)
        {
            try
            {
                // Validate registrationDto and create a new user account
                var user = _userService.RegisterUser(registrationDto);

                return Ok(new { Message = "Registration successful", UserId = user.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to register user", Error = ex.Message });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous] // Allow anonymous access for login
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                // Authenticate the user based on loginDto
                var user = _userService.AuthenticateUser(loginDto);

                if (user != null)
                {
                    // Generate and return an authentication token (JWT) if authentication is successful
                    var token = _userService.GenerateJwtToken(user);

                    return Ok(new { Token = token, Message = "Login successful" });
                }

                return Unauthorized(new { Message = "Invalid credentials" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to authenticate user", Error = ex.Message });
            }
        }

        [HttpGet("profile")]
        public IActionResult GetUserProfile()
        {
            try
            {
                // Get the authenticated user's ID (assuming user ID is in claims)
                var userId = Guid.Parse(User.Identity.Name);

                // Retrieve user profile using the userService
                var userProfile = _userService.GetUserProfile(userId);

                return Ok(userProfile);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to retrieve user profile", Error = ex.Message });
            }
        }

        [HttpPut("profile")]
        public IActionResult UpdateUserProfile([FromBody] UserProfileDto userProfileDto)
        {
            try
            {
                // Get the authenticated user's ID (assuming user ID is in claims)
                var userId = Guid.Parse(User.Identity.Name);

                // Update user profile using the userService
                _userService.UpdateUserProfile(userId, userProfileDto);

                return Ok(new { Message = "Profile updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to update user profile", Error = ex.Message });
            }
        }
    }
}
