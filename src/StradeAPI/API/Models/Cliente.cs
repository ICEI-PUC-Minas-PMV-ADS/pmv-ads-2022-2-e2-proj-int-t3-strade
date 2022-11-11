using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdCliente { get; set; }
        public int? IdInformacao { get; set; }
        public int? IdLoja { get; set; }

        public virtual Informacao? IdInformacaoNavigation { get; set; }
        public virtual Loja? IdLojaNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
