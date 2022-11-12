using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Loja
    {
        public Loja()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdLoja { get; set; }
        public string Cnpj { get; set; } = null!;
        public int? IdInformacao { get; set; }

        public virtual Informacao? IdInformacaoNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
