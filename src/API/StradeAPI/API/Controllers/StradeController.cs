using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/controller")]
    public class StradeController : ControllerBase
    {
        protected BairroController _bairrosController;
        protected PedidoController _pedidosController;
        protected TransportadoraController _transportadorasController;
        public StradeController () {
            _bairrosController = new BairroController();
            _pedidosController = new PedidoController();
            _transportadorasController = new TransportadoraController();
        }
    }
}
