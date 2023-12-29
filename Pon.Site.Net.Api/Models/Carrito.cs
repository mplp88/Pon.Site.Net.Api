namespace Pon.Site.Net.Api.Models
{
    public class Carrito
    {
        public Guid Id { get; set; }
        public IEnumerable<ProductoPedido> Productos { get; set; }
    }
}
