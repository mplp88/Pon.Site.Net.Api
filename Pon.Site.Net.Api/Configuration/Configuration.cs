using Pon.Site.Net.Api.Services;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Configuration
{
    public static class Configuration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoService, ToDoService>();
        }
    }
}
