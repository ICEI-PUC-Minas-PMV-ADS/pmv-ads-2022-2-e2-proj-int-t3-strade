namespace API.DTOs {
    public class TransportadoraDTO : InformacaoDTO {
        public int IdTransportadora { get; set; }
        public string Cnpj { get; set; } = null!;
        public int? NotaMediaQualidade { get; set; }
        public int? MediaPreco { get; set; }
        public List<BairroDTO>? Bairros { get; set; }
    }
}
