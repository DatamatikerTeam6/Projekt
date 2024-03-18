using HundeProjekt.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HundeProjekt.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICourseViewCounter _courseViewCounter;

        public MyMiddleware(RequestDelegate next, ICourseViewCounter courseViewCounter)
        {
            _next = next;
            _courseViewCounter = courseViewCounter;
          
        }   

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments(new PathString("/Courses/ViewCourse/11")))
            {
                _courseViewCounter.IncrementCounter();
            }

           await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
