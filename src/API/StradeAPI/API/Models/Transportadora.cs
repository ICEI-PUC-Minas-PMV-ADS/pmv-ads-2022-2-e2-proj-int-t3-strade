using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Transportadora
    {
        public Transportadora()
        {
            BairroTransportadoras = new HashSet<BairroTransportadora>();
        }

        public int IdTransportadora { get; set; }
        public string Cnpj { get; set; } = null!;
        public int? NotaMediaQualidade { get; set; }
        public int? MediaPreco { get; set; }
        public int? IdInformacao { get; set; }

        public virtual Informacao? IdInformacaoNavigation { get; set; }
        public virtual ICollection<BairroTransportadora> BairroTransportadoras { get; set; }
    }
}
