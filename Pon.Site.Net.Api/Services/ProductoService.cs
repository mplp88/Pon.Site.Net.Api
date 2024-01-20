using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Context;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Services
{
    public class ProductoService : IProductoService
    {
        private readonly PonSiteApiContext _context;

        public ProductoService(PonSiteApiContext context)
        {
            _context = context;
        }

        public async Task<Producto> Add(Producto producto)
        {
            producto.Id = Guid.NewGuid();
            var entry = await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var producto = await GetById(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Producto?> GetById(Guid id)
        {
            return _context.Productos
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _context.Productos
                .ToListAsync();
        }

        public async Task<Producto> Update(Producto productoActualizado)
        {
            var producto = await GetById((Guid)productoActualizado.Id);
            
            producto.Nombre = productoActualizado.Nombre;
            producto.Descripcion = productoActualizado.Descripcion;
            producto.Precio = productoActualizado.Precio;
            producto.CategoriaId = productoActualizado.CategoriaId;
            
            var entry = _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
