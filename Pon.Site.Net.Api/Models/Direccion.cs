using Microsoft.EntityFrameworkCore;

namespace Pon.Site.Net.Api.Models
{
    [Owned]
    public class Direccion
    {
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        public string Aclaracion { get; set; }
        public string EntreCalle1 { get; set; }
        public string EntreCalle2 { get; set; }
        public Coordenada Coordenada { get; set; }
    }
}
