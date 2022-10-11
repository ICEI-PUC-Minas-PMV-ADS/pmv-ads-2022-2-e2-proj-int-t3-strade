using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class BairroTransportadora
    {
        public int IdBairroTransportadora { get; set; }
        public int? IdBairro { get; set; }
        public int? IdTransportadora { get; set; }

        public virtual Bairro? IdBairroNavigation { get; set; }
        public virtual Transportadora? IdTransportadoraNavigation { get; set; }
    }
}
