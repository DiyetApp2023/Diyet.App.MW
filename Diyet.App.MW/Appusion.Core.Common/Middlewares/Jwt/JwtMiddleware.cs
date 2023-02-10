using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.ExceptionBase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
        public JwtMiddleware(RequestDelegate nextMiddleware)
        {
            _nextMiddleware = nextMiddleware;
        }

        public async Task Invoke(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            var httpRequest = httpContext.Request;
            if (httpRequest.Path.HasValue)
            {
                if (string.Equals(httpRequest.Path.Value, "/api/user/register",StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(httpRequest.Path.Value, "/api/user/activateuser", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(httpRequest.Path.Value, "/api/user/authenticate", StringComparison.OrdinalIgnoreCase) ||
                      string.Equals(httpRequest.Path.Value, "/api/user/forgotpassword", StringComparison.OrdinalIgnoreCase) ||
                      string.Equals(httpRequest.Path.Value, "/api/user/changepassword", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(httpRequest.Path.Value, "/api/user/refresh", StringComparison.OrdinalIgnoreCase)
                    )
                {
                    await _nextMiddleware.Invoke(httpContext);
                    return;
                }
            }
            if (!httpRequest.Headers.ContainsKey("Authorization"))
            {
                httpContext.Response.StatusCode = 427;
                await httpContext.Response.WriteAsync("Jwt gönderilmedi.");
                return;
            }
            try
            {
                var accessToken = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                
                if (string.IsNullOrEmpty(accessToken))
                {
                    await httpContext.Response.WriteAsync("Jwt içeriği gönderilmedi.");
                    return;
                }
                var jwtUtils = httpContext.RequestServices.GetRequiredService<IJwtUtils>();
                var userId = await jwtUtils.ValidateAccessToken(accessToken);
                if (userId != null)
                {
                    var userSessionRepository = httpContext.RequestServices.GetRequiredService<IUserSessionRepository>();
                    var userSession = await userSessionRepository.GetUserSessionEntity(new RequestModels.User.GetUserSessionEntityRequestPackage
                    {
                        UserId = Convert.ToInt64(userId),
                        AccessToken = accessToken
                    });
                    if (userSession == null)
                    {
                        await httpContext.Response.WriteAsync("Kullanıcı ile ilişkili bir oturum bulunamamıştır.");
                        return;
                    }
                    else
                    {
                        httpContext.Items["UserId"] = Convert.ToInt64(userId);
                        await _nextMiddleware.Invoke(httpContext);
                    }
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("Oturum doğrulanamamıştır.");
                }
            }
            catch (Exception exception)
            {
                throw new MiddlewareException("JwtMiddleware seviyesinde hata oluştu. Hata: " + exception.Message);
            }
        }
    }
}