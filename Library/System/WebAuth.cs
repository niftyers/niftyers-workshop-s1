using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.BuildersAPI
{
    public class WebAuth
    {
        private readonly RequestDelegate _next;
        private readonly IAppConfig appConfig;

        public WebAuth(RequestDelegate next, IAppConfig config)
        {
            _next = next;
            appConfig = config;
        }

        public async Task Invoke(HttpContext context)
        {

            var IsApi = context.Request.Path.Value.Contains("/api/");

            if (!IsApi == true)
            {
                await _next(context);
                return;
            }

            var Token = context.Request.Headers["X-Niftyers"].ToNullString();

            if (Token.Equals("") || !Token.Equals(appConfig.Token))
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Something went wrong in your request!");
                return;
            }

            await _next(context);
        }
    }
}
