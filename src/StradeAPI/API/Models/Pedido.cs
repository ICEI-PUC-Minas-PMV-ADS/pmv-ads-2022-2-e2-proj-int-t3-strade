using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public string? Detalhes { get; set; }
        public int? IdTransportadora { get; set; }
        public int? IdCliente { get; set; }
        public int? Status { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Transportadora? IdTransportadoraNavigation { get; set; }
    }
}
