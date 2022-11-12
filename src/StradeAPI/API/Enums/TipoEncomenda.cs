using System.ComponentModel.DataAnnotations;

namespace API.Enums {
    public enum TipoEncomenda {

        Fragil = 0,
        Pequeno = 1,
        Medio = 2,
        Grande = 3,
        Vivo = 4,
        Pesado = 5,
        Perigoso = 6,
        Inflamavel = 7,
    }

    public enum StatusEncomenda {

        [Display(Name="A encomenda já foi separada, aguardando ser enviada")]
        Separado = 0,

        [Display(Name="O pedido foi enviado pela transportadora")]
        Enviada = 1,

        [Display(Name="O pedido está a caminho de sua residência. Logo estará em suas mãos")]
        ACaminho = 2,

        [Display(Name="Pedido entregue")]
        Entregue = 3,

        [Display(Name="Pedido cancelado. Contate a loja ou a transportadora para mais informações")]
        Cancelado = 4,
    }
}
