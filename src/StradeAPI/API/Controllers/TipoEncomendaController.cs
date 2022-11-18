using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class TipoEncomendaController : ControllerBase {

        [HttpPost]
        [Route("encomenda/tipo")]
        public async Task<ActionResult<bool>> SaveTipoEncomenda([FromServices] DataContext context, List<TipoEncomenda> tipos, int idTransportadora){

            if(tipos != null || !tipos.Any())
                return Ok(false);

            var tipoEncomendas = new List<TransportadoraTipoEncomendum>();

            foreach(var tipo in tipos)
                tipoEncomendas.Add(new TransportadoraTipoEncomendum() { IdTipo = (int)tipo, IdTransportadora = idTransportadora });

            context.TransportadoraTipoEncomenda.AddRange(tipoEncomendas);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
