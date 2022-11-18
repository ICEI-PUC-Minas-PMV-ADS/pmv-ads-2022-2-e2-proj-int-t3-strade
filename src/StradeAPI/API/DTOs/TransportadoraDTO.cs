namespace API.DTOs {
    public class TransportadoraDTO : InformacaoDTO {
        public int IdTransportadora { get; set; }
        public string Cnpj { get; set; } = null!;
        public int? NotaMediaQualidade { get; set; }
        public int? MediaPreco { get; set; }
        public int[] Regioes { get; set; }
        public int[] TipoEncomendas { get; set; }

        public List<string> RegioesDto { get; set; }
        public List<string> TipoEncomendasDto { get; set; }
    }
}
