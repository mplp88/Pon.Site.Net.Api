namespace Pon.Site.Net.Api.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public int NumeroPedido { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<ProductoPedido> Productos { get; set; }
        public decimal Total { get; set; }
    }
}
