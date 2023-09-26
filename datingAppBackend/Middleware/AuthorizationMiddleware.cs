using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YourNamespace.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the user is authenticated
            if (context.User.Identity.IsAuthenticated)
            {
                // Get the user's claims
                var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    // Get the user's identifier from the claim
                    string userId = userIdClaim.Value;

                    // Perform authorization checks based on the user's identifier
                    if (IsUserAuthorized(userId))
                    {
                        // User is authorized; continue processing the request
                        await _next(context);
                    }
                    else
                    {
                        // User is not authorized; return a forbidden response
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return;
                    }
                }
            }

            // User is not authenticated; return an unauthorized response
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }

        private bool IsUserAuthorized(string userId)
        {
            // Implement your custom authorization logic here
            // Check if the user identified by 'userId' has the required permissions
            // Return 'true' if authorized, 'false' otherwise

            // Example: Check if the user has a specific role
            return userId == "user123" || userId == "admin";
        }
    }
}
