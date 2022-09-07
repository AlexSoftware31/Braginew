using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bragi.Web.Configurations.Middlewares
{
    public class SerilogRequestLogger
    {
        readonly RequestDelegate _next;

        public SerilogRequestLogger(RequestDelegate next)
        {
            if (next == null) 
                throw new ArgumentNullException(nameof(next));
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            string requestBody = await ExtractRequestBody(httpContext);

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                LogException(ex, httpContext, requestBody);
                throw;
            }
        }

        private void LogException(Exception ex, HttpContext httpContext, string requestBody)
        {
            LogContext.PushProperty("Method", httpContext.Request.Method);
            LogContext.PushProperty("Host", httpContext.Request.Host);
            LogContext.PushProperty("Path", httpContext.Request.Path);
            LogContext.PushProperty("QueryString", httpContext.Request.QueryString);
            LogContext.PushProperty("RequestId", httpContext.TraceIdentifier);
            Log.Logger
                .ForContext("RequestBody", requestBody)
                .ForContext("Status Code", httpContext.Response.StatusCode)
                .Error(ex, ex.Message);
        }

        private async Task<string> ExtractRequestBody(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            Stream body = httpContext.Request.Body;
            byte[] buffer = new byte[Convert.ToInt32(httpContext.Request.ContentLength)];
            await httpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            string requestBody = Encoding.UTF8.GetString(buffer);
            body.Seek(0, SeekOrigin.Begin);
            httpContext.Request.Body = body;
            return requestBody;
        }
    }
}
