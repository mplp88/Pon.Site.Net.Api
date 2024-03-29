﻿using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Models;

namespace Pon.Site.Net.Api.Context
{
    public class PonSiteApiContext : DbContext
    { 
        public PonSiteApiContext(DbContextOptions<PonSiteApiContext> options) 
            : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
    }
}
