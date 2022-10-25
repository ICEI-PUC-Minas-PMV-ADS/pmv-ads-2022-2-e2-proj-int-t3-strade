using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class TransportadoraTipoEncomendum
    {
        public int IdTransportadoraTipoEncomenda { get; set; }
        public int? IdTipo { get; set; }
        public int? IdTransportadora { get; set; }

        public virtual Transportadora? IdTransportadoraNavigation { get; set; }
    }
}
