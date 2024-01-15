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

        public async Task<Carrito> AddProduct(Guid? id, Producto producto)
        {
            Carrito carrito;
            if(id != null)
            {
                carrito = await Get((Guid)id);
            }
            else
            {
                carrito = new Carrito();
            }

            if(carrito.Productos.Any(p => p.ProductoId == producto.Id))
            {
                var productos = carrito.Productos;
                var productoPedido = productos.First(c => c.ProductoId == producto.Id);
                productoPedido.Cantidad++;
                productoPedido.Valor = producto.Precio * productoPedido.Cantidad;
                carrito.Productos = productos;
            }
            else
            {
                var productoPedido = new ProductoPedido();
                productoPedido.ProductoId = producto.Id;
                productoPedido.Cantidad = 1;
                productoPedido.Valor = producto.Precio * productoPedido.Cantidad;
                var productos = carrito.Productos.ToList();
                productos.Add(productoPedido);
                carrito.Productos = productos;
            }

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
            Carrito carrito;
            if(id != null)
            {
                carrito = await Get((Guid)id);
            }
            else
            {
                carrito = new Carrito();
            }

            var productos = carrito.Productos.ToList();
            productos.Clear();
            carrito.Productos = productos;

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

        public async Task<Carrito> GetByClienteId(Guid? clienteId)
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

        public async Task<Carrito> RemoveProduct(Guid? id, Producto producto)
        {
            Carrito carrito;
            if (id != null)
            {
                carrito = await Get((Guid)id);
            }
            else
            {
                carrito = new Carrito();
            }

            if (carrito.Productos.Any(p => p.Producto == producto))
            {
                var productoPedido = carrito.Productos.First(c => c.Producto == producto);
                productoPedido.Cantidad--;

                if(productoPedido.Cantidad == 0)
                {
                    carrito.Productos.ToList().Remove(productoPedido);
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
