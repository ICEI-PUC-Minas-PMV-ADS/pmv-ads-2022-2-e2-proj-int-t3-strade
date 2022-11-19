using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class PedidoController : ControllerBase {

        [HttpPost]
        [Route("pedido")]
        public async Task<ActionResult<bool>> SavePedido([FromServices] DataContext context, PedidoDTO pedido){

            if(pedido is null)
                return NotFound("Pedido não pode vim nulo.");

            if(pedido.IdCliente <= 0)
                return NotFound("Pedido deve conter um cliente.");

            var pedidoModel = new Pedido() {
                Detalhes = pedido.Detalhes,
                IdCliente = pedido.IdCliente,
                IdPedido = pedido.IdPedido,
                IdTransportadora = pedido.IdTransportadora,
                Status = (int)Status.PedidoRealizado
            };


            context.Add(pedidoModel);
            await context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpGet]
        [Route("pedido")]
        public async Task<ActionResult<List<PedidoDTO>>> GetPedidos([FromServices] DataContext context){
            return Ok((await context.Pedidos.ToListAsync()).Select(pedido => new PedidoDTO() {
                Detalhes = pedido.Detalhes,
                IdCliente = pedido.IdCliente,
                IdPedido = pedido.IdPedido,
                IdTransportadora = pedido.IdTransportadora,
                Status = (int)Status.PedidoRealizado
            }));
        }

        [HttpGet]
        [Route("pedido/{idPedido}")]
        public async Task<ActionResult<PedidoDTO>> GetPedidoById([FromServices] DataContext context, [FromRoute] int idPedido){

            if(idPedido is 0)
                return NotFound("Id do pedido não pode vim com valor 0.");

            var pedido = await context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == idPedido);

            if(pedido != null)
                return Ok(new PedidoDTO() {
                    Detalhes = pedido.Detalhes,
                    IdCliente = pedido.IdCliente,
                    IdPedido = pedido.IdPedido,
                    IdTransportadora = pedido.IdTransportadora,
                    Status = (int)Status.PedidoRealizado
                });

            return NotFound("Pedido inexistente.");
        }

        [HttpDelete]
        [Route("pedido/{idPedido}")]
        public async Task<ActionResult<bool>> DeletePedidoById([FromServices] DataContext context, [FromRoute] int idPedido){

            if(idPedido is 0)
                return NotFound("Id do pedido não pode vim com valor 0.");

            var pedido = await context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == idPedido);

            if(pedido != null) {
                context.Pedidos.Remove(pedido);
                await context.SaveChangesAsync();
                return Ok(true);
            }     

            return NotFound("Pedido inexistente.");
        }

        [HttpGet]
        [Route("pedido/{idPedido}/cliente")]
        public async Task<ActionResult<string>> GetNomeClienteByIdPedido([FromServices] DataContext context, [FromRoute] int idPedido){

            if(idPedido == 0)
                return NotFound("Id do pedido inválido.");

            var nomeCliente = await (from p in context.Pedidos
                                join c in context.Clientes on p.IdCliente equals c.IdCliente
                                join i in context.Informacaos on c.IdInformacao equals i.IdInformacao
                                where p.IdPedido == idPedido
                                select i.Nome).FirstOrDefaultAsync(); 

            if(!string.IsNullOrEmpty(nomeCliente)) {
                return Ok(nomeCliente);
            }
                

            return NotFound("Pedido/Cliente não encontrado");
        }

    }
}
