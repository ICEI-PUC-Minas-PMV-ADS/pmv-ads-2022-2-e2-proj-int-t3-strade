using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Transportadora
    {
        public Transportadora()
        {
            Pedidos = new HashSet<Pedido>();
            RegiaoTransportadoras = new HashSet<RegiaoTransportadora>();
            TransportadoraTipoEncomenda = new HashSet<TransportadoraTipoEncomendum>();
        }

        public int IdTransportadora { get; set; }
        public string Cnpj { get; set; } = null!;
        public int? NotaMediaQualidade { get; set; }
        public int? MediaPreco { get; set; }
        public int? IdInformacao { get; set; }

        public virtual Informacao? IdInformacaoNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<RegiaoTransportadora> RegiaoTransportadoras { get; set; }
        public virtual ICollection<TransportadoraTipoEncomendum> TransportadoraTipoEncomenda { get; set; }
    }
}
