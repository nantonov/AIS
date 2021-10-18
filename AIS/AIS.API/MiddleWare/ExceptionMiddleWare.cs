using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AIS.API.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<ExceptionMiddleWare> logger)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{ex.Message}");
                logger.LogError(ex.Message);
            }
        }
    }
}