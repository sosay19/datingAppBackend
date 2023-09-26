using datingAppBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using YourNamespace.Services; // Import your matching service

namespace YourNamespace.Controllers
{
    [Route("api/matching")]
    [ApiController]
    [Authorize] // Require authentication for matching operations
    public class MatchingController : ControllerBase
    {
        private readonly IMatchingService _matchingService;

        public MatchingController(IMatchingService matchingService)
        {
            _matchingService = matchingService;
        }

        [HttpGet("user-matches")]
        public IActionResult GetUserMatches()
        {
            try
            {
                // Get the authenticated user's ID (assuming user ID is in claims)
                var userId = Guid.Parse(User.Identity.Name);

                // Retrieve user matches using the matching service
                var userMatches = _matchingService.GetUserMatches(userId);

                return Ok(userMatches);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to retrieve user matches", Error = ex.Message });
            }
        }

        [HttpGet("item-matches")]
        public IActionResult GetItemMatches()
        {
            try
            {
                // Retrieve item matches using the matching service
                var itemMatches = _matchingService.GetItemMatches();

                return Ok(itemMatches);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to retrieve item matches", Error = ex.Message });
            }
        }
    }
}
