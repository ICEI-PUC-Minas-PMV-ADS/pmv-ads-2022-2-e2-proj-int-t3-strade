namespace API.DTOs {
    public class PedidoDTO {
        public int IdPedido { get; set; }
        public string? Detalhes { get; set; }
        public int? IdTransportadora { get; set; }
        public int? IdCliente { get; set; }
        public int? Status { get; set; }
    }

    public enum Status {
        PedidoRealizado = 0,
        EntregueTransportadora = 1,
        ACaminho = 2,
        Entregue = 3
    }
}
