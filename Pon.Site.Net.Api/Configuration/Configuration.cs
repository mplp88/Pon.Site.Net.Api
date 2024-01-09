using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Configuration
{
    public static class Configuration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IService<Item>, ToDoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProductoService, ProductoService>();
        }
    }
}
