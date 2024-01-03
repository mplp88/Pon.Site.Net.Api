using Microsoft.EntityFrameworkCore;

namespace Pon.Site.Net.Api.Models
{
    [Owned]
    public class Categoria
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
    }
}
