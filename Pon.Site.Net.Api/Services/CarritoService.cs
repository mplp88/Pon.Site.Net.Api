using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Context;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly PonSiteApiContext _context;

        public CarritoService(PonSiteApiContext context)
        {
            _context = context;
        }

        public async Task<Carrito> Add(Carrito carrito)
        {
            var entry = await _context.AddAsync(carrito);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Carrito> AddProduct(Guid id, Producto producto)
        {
            var carrito = await Get(id);
            
            var productos = carrito.Productos.ToList();

            if(carrito.Productos.Any(p => p.ProductoId == producto.Id))
            {
                var productoPedido = productos.First(c => c.ProductoId == producto.Id);
                productoPedido.Cantidad++;
                productoPedido.Valor = producto.Precio * productoPedido.Cantidad;
            }
            else
            {
                var productoPedido = new ProductoPedido();
                productoPedido.ProductoId = producto.Id;
                productoPedido.Cantidad = 1;
                productoPedido.Valor = producto.Precio * productoPedido.Cantidad;
                productos.Add(productoPedido);
            }

            carrito.Productos = productos;
            carrito.Total = productos.Select(x => x.Valor).Sum();
            var entry = _context.Update(carrito);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var carrito = await Get(id);
            _context.Carritos.Remove(carrito);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Carrito> EmptyCart(Guid id)
        {
            var carrito = await Get(id);

            var productos = carrito.Productos.ToList();
            productos.Clear();
            carrito.Productos = productos;
            carrito.Total = 0;

            _context.Update(carrito);
            await _context.SaveChangesAsync();
            return carrito;
        }

        public async Task<Carrito?> Get(Guid id)
        {
            var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.Id == id);
            return carrito;
        }

        //Esta función no debería ser llamada
        public async Task<IEnumerable<Carrito>> Get()
        {
            return await Task.FromResult<IEnumerable<Carrito>>(new List<Carrito>());
        }

        public async Task<Carrito> GetByClienteId(Guid clienteId)
        {
            var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
            if (carrito == null)
            {
                carrito = new Carrito();
                carrito.ClienteId = clienteId;
                await Add(carrito);
            }

            return carrito;
        }

        public async Task<Carrito> RemoveProduct(Guid id, Producto producto)
        {
            var carrito = await Get((Guid)id);

            if (carrito.Productos.Any(p => p.Producto.Id == producto.Id))
            {
                var productos = carrito.Productos.ToList();
                var productoPedido = productos.First(c => c.Producto.Id == producto.Id);
                productoPedido.Cantidad--;

                productoPedido.Valor = productoPedido.Producto.Precio * productoPedido.Cantidad;

                if(productoPedido.Cantidad == 0)
                {
                    productos.Remove(productoPedido);
                }

                carrito.Productos = productos;
                carrito.Total = 0;

                if (productos.Any())
                {
                    carrito.Total = productos.Select(x => x.Valor).Sum();
                }    
            }

            _context.Update(carrito);
            await _context.SaveChangesAsync();
            return carrito;
        }

        //Esta función no debería ser llamada
        public async Task<Carrito> Update(Carrito carritoActualizado)
        {
            return await Task.FromResult(new Carrito());
        }
    }
}
