namespace Pon.Site.Net.Api.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Direccion> Direccion { get; set; }
        public IEnumerable<Telefono> Telefonos { get; set; }
    }
}
