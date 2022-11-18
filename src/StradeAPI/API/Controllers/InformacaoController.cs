using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class InformacaoController : ControllerBase {

        [HttpPost]
        [Route("informacao")]
        public async Task<ActionResult<int>> SaveInformacao([FromServices] DataContext context, InformacaoDTO informacaoDto){

            if(informacaoDto is null)
                return NotFound("Informacao inválida.");

            var informacao = new Informacao() {
                Nome = informacaoDto.Nome,
                IdInformacao = informacaoDto.IdInformacao,
                Aniversario = informacaoDto.Aniversario,
                Email = informacaoDto.Email,
                Endereco = informacaoDto.Endereco,
                NumeroContato = informacaoDto.NumeroContato,
                Senha =informacaoDto.Senha

            };

            context.Informacaos.Add(informacao);
            await context.SaveChangesAsync();

            return informacao.IdInformacao;
        }

        [HttpGet]
        [Route("informacao/{idInformacao}")]
        public async Task<ActionResult<InformacaoDTO>> GetInformacao([FromServices] DataContext context, [FromRoute] int? idInformacaoDto){

            if(idInformacaoDto == 0)
                return NotFound("ID Informacao inválido.");

            var informacaoModel = await context.Informacaos.FirstOrDefaultAsync(i => i.IdInformacao == idInformacaoDto);

            if(informacaoModel != null) {
                return Ok(new Informacao() {
                    Nome = informacaoModel.Nome,
                    IdInformacao = informacaoModel.IdInformacao,
                    Aniversario = informacaoModel.Aniversario,
                    Email = informacaoModel.Email,
                    Endereco = informacaoModel.Endereco,
                    NumeroContato = informacaoModel.NumeroContato
                });
            }

            return NotFound("Informacao Inexistente.");
            ;
        }
    }
}
