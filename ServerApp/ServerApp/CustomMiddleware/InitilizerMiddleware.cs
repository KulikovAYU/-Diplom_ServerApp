using System.Threading.Tasks;
using FC_EMDB.Database.Initializer;
using FC_EMDB.Database.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ServerApp.CustomMiddleware
{
    public class InitilizerMiddleware
    {
        private RequestDelegate _next;
        public InitilizerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,IUnitOfWork unitOfWork)
        {
            await _next(context);
            DbInitializer.Seed(unitOfWork);
           
        }
    }

    public static class InitilizerMiddlewareExtentions
    {
        public static IApplicationBuilder UseEFCoreInitializer(this IApplicationBuilder builder)
        {
           return builder.UseMiddleware<InitilizerMiddleware>();
        }
    }
}
