using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Informacao
    {
        public Informacao()
        {
            Clientes = new HashSet<Cliente>();
            Lojas = new HashSet<Loja>();
            Transportadoras = new HashSet<Transportadora>();
        }

        public int IdInformacao { get; set; }
        public string Nome { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public DateTime? Aniversario { get; set; }
        public string NumeroContato { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Loja> Lojas { get; set; }
        public virtual ICollection<Transportadora> Transportadoras { get; set; }
    }
}
