namespace API.DTOs {
    public class InformacaoDTO {
        public int IdInformacao { get; set; }
        public string Nome { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public DateTime? Aniversario { get; set; }
        public string NumeroContato { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
