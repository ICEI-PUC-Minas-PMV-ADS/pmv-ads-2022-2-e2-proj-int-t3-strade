using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Bairro
    {
        public Bairro()
        {
            BairroTransportadoras = new HashSet<BairroTransportadora>();
        }

        public int IdBairro { get; set; }
        public string Nome { get; set; } = null!;
        public string Cep { get; set; } = null!;

        public virtual ICollection<BairroTransportadora> BairroTransportadoras { get; set; }
    }
}
