using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class ClienteController : ControllerBase {

        private InformacaoController _informacaoController = new InformacaoController();

        [HttpGet]
        [Route("cliente")]
        public async Task<ActionResult<List<ClienteDTO>>> GetCliente([FromServices] DataContext context){
            return Ok((await context.Clientes.ToListAsync()).Select(async c => new ClienteDTO() {
                IdCliente = c.IdCliente,
                IdInformacao = c.IdInformacao,
                Informacao = (await _informacaoController.GetInformacao(context, c.IdInformacao)).Value ?? new InformacaoDTO()
            }));
        }

        [HttpPost]
        [Route("cliente")]
        public async Task<ActionResult<bool>> SaveClient([FromServices] DataContext context, [FromBody] ClienteDTO cliente){

            if(cliente is null)
                return NotFound("Cliente não pode vim nulo.");

            var idInformacao = await _informacaoController.SaveInformacao(context, cliente.Informacao);

            var clienteModel = new Cliente() {
                IdInformacao = idInformacao.Value
            };


            context.Add(clienteModel);
            await context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpGet]
        [Route("cliente/{idCliente}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente([FromServices] DataContext context, [FromRoute] int idCliente){

            if(idCliente == 0)
                return NotFound("Id do cliente inválido.");

            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == idCliente);

            if(cliente != null)
                return Ok(new ClienteDTO() {
                    IdCliente = cliente.IdCliente,
                    Informacao = (await _informacaoController.GetInformacao(context, cliente.IdInformacao)).Value ?? new InformacaoDTO()
                });

            return NotFound("Cliente não encontrado");
        }

        [HttpDelete]
        [Route("cliente/{idCliente}")]
        public async Task<ActionResult<bool>> DeleteCliente([FromServices] DataContext context, [FromRoute] int idCliente){

            if(idCliente == 0)
                return NotFound("Id do cliente inválido.");

            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == idCliente);

            if(cliente != null) {
                context.Remove(cliente);
                await context.SaveChangesAsync();
            }
                

            return NotFound("Cliente não encontrado");
        }

    }
}
