using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Models;

namespace Pon.Site.Net.Api.Context
{
    public class PonSiteApiContext : DbContext
    { 
        public PonSiteApiContext(DbContextOptions<PonSiteApiContext> options) 
            : base(options) { }

        public DbSet<Item> ToDos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
