﻿namespace Pon.Site.Net.Api.Models
{
    public class ProductoPedido
    {
        public Guid? ProductoId { get; set; }
        public virtual Producto? Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Valor { get; set; } 
    }
}
