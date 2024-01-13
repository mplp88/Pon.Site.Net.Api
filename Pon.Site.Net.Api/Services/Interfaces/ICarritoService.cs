using Pon.Site.Net.Api.Models;

namespace Pon.Site.Net.Api.Services.Interfaces
{
    public interface ICarritoService : IService<Carrito>
    {
        Task<Carrito> AddProduct(Guid? carritoId, Producto producto);
        Task<Carrito> GetByClienteId(Guid? clienteId);
        Task<Carrito> RemoveProduct(Guid? carritoId, Producto producto);
    }
}
