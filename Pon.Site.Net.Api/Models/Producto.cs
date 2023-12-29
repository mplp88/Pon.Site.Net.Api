namespace Pon.Site.Net.Api.Models
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
    }
}
