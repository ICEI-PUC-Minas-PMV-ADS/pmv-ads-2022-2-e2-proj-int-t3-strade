using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public int? IdInformacao { get; set; }
        public int? IdLoja { get; set; }

        public virtual Informacao? IdInformacaoNavigation { get; set; }
        public virtual Loja? IdLojaNavigation { get; set; }
    }
}
