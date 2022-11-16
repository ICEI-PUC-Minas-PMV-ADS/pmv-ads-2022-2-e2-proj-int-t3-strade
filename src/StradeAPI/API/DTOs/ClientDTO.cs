namespace API.DTOs {
    public class ClienteDTO {

        public ClienteDTO () {

        }

        public int IdCliente { get; set; }
        public InformacaoDTO Informacao { get; set; }
        public int? IdInformacao { get; set; }
        public int? IdLoja { get; set; }
    }
}
