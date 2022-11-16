namespace API.DTOs {
    public class RegiaoDTO {
        public int IdRegiaoTransportadora { get; set; }
        public Regiao IdRegiao { get; set; }
        public int? IdTransportadora { get; set; }
    }

    public enum Regiao {
        Norte = 1,
        Sul = 2,
        Leste = 3,
        Oeste = 4
    }
    
}
