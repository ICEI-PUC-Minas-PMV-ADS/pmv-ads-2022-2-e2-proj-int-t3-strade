using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class RegiaoTransportadora
    {
        public int IdRegiaoTransportadora { get; set; }
        public int IdRegiao { get; set; }
        public int? IdTransportadora { get; set; }

        public virtual Transportadora? IdTransportadoraNavigation { get; set; }
    }
}
