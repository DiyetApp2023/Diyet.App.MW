using Appusion.Core.Common.Interface.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Middlewares.Jwt
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;
        private readonly IUserService _userService;
        private readonly IJwtUtils _jwtUtils;

        public JwtMiddleware(RequestDelegate nextMiddleware, IUserService userService, IJwtUtils jwtUtils)
        {
            _nextMiddleware = nextMiddleware;
            _userService = userService;
            _jwtUtils = jwtUtils;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var httpRequest = httpContext.Request;
            if (httpRequest.Path.HasValue)
            {
                if (string.Equals(httpRequest.Path.Value, "/api/auth/register",StringComparison.OrdinalIgnoreCase))
                {
                    await _nextMiddleware.Invoke(httpContext);
                }
            }
            if (httpRequest.Headers.ContainsKey("Authorization"))
            {
                httpContext.Response.StatusCode = 427;
                await httpContext.Response.WriteAsync("Jwt gönderilmedi.");
                return;
            }
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                //httpContext.Items["User"] = _userService.GetById(userId.Value);
            }

            await _nextMiddleware(httpContext);
        }
    }
}
