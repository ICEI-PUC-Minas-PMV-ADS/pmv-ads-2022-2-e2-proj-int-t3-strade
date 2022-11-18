using System.ComponentModel;

namespace API.DTOs {
    public class RegiaoDTO {
        public int IdRegiaoTransportadora { get; set; }
        public Regiao IdRegiao { get; set; }
        public int? IdTransportadora { get; set; }
    }

    public enum Regiao {

        [Description("Norte")]
        Norte = 1,

        [Description("Sul")]
        Sul = 2,

        [Description("Leste")]
        Leste = 3,

        [Description("Oeste")]
        Oeste = 4
    }

    public enum TipoEncomenda {

        [Description("Frágil")]
        Frágil = 1,

        [Description("Pequeno Porte")]
        PequenoPorte = 2,

        [Description("Medio Porte")]
        MedioPorte = 3,

        [Description("Grande Porte")]
        GrandePorte = 4,

        [Description("Vivo")]
        Vivo = 5,

        [Description("Pesado")]
        Pesado = 6,

        [Description("Perigoso")]
        Perigoso = 7,

        [Description("Inflamável")]
        Inflamavel = 8
    }
    
}
