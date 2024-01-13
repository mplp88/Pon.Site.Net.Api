namespace Pon.Site.Net.Api.Models
{
    public class Carrito
    {
        public Guid? Id { get; set; }
        public Guid? ClienteId { get; set; }
        public virtual IEnumerable<ProductoPedido> Productos { get; set; } = new List<ProductoPedido>();
    }
}
