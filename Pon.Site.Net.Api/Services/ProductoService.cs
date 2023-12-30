using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Context;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Services
{
    public class ProductoService : IService<Producto>
    {
        private readonly PonSiteApiContext _context;

        public ProductoService(PonSiteApiContext context)
        {
            _context = context;
        }

        public async Task<Producto> Add(Producto producto)
        {
            var entry = await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var producto = await Get(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Producto?> Get(Guid id)
        {
            return _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Producto>> Get()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> Update(Producto model)
        {
            var entry = _context.Productos.Update(model);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
