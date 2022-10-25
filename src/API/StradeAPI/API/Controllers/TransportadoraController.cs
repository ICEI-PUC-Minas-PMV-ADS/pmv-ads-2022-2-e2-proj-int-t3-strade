using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class TransportadoraController : ControllerBase {

        private BairroController _bairroController;

        public TransportadoraController () {
            _bairroController = new BairroController();
        }

        [HttpGet]
        [Route("transportadora")]
        public async Task<ActionResult<List<TransportadoraDTO>>> GetTransportadoras([FromServices] DataContext context){

            var transportadoras = await (from trans in context.Transportadoras
                                         let bairrosVinculados = context.BairroTransportadoras
                                                .Where(bt => bt.IdTransportadora == trans.IdTransportadora)
                                                .ToList()
                                         let info = context.Informacaos
                                                .FirstOrDefault(i => i.IdInformacao == trans.IdInformacao)
                                         select new TransportadoraDTO() {

                                             IdInformacao = info.IdInformacao,
                                             Nome = info.Nome,
                                             Email = info.Email,
                                             Endereco = info.Endereco,
                                             Aniversario = info.Aniversario,
                                             NumeroContato = info.NumeroContato,

                                             IdTransportadora = trans.IdTransportadora,
                                             Cnpj = trans.Cnpj,
                                             MediaPreco = trans.MediaPreco,
                                             NotaMediaQualidade = trans.NotaMediaQualidade,
                                             
                                             Bairros =  (from b in context.Bairros
                                                        join bv in bairrosVinculados on b.IdBairro equals bv.IdBairro
                                                        select new BairroDTO() {
                                                            IdBairro = b.IdBairro,
                                                            Cep = b.Cep,
                                                            Nome = b.Nome,
                                                        }).ToList(),

                                         }).ToListAsync();
                                         
            if(transportadoras != null && transportadoras.Count > 0) {
                return Ok(transportadoras);
            }

            return NotFound("Não existe transportadoras.");
        }

        [HttpGet]
        [Route("transportadora/cep/{cep}")]
        public async Task<ActionResult<List<TransportadoraDTO>>> GetTransportadorasByCEP([FromServices] DataContext context, [FromRoute] string cep){
            var bairro = await context.Bairros.FirstOrDefaultAsync(b => b.Cep.Equals(cep));

            if(bairro != null) {
                var transportadoras = await (from trans in context.Transportadoras
                                         where trans.BairroTransportadoras.Where(t => t.IdBairro == bairro.IdBairro).Count() > 0
                                         let info = context.Informacaos
                                                .FirstOrDefault(i => i.IdInformacao == trans.IdInformacao)
                                         select new TransportadoraDTO() {

                                             IdInformacao = info.IdInformacao,
                                             Nome = info.Nome,
                                             Email = info.Email,
                                             Endereco = info.Endereco,
                                             Aniversario = info.Aniversario,
                                             NumeroContato = info.NumeroContato,

                                             IdTransportadora = trans.IdTransportadora,
                                             Cnpj = trans.Cnpj,
                                             MediaPreco = trans.MediaPreco,
                                             NotaMediaQualidade = trans.NotaMediaQualidade,

                                         }).ToListAsync();

                if(transportadoras != null && transportadoras.Count() > 0) {
                    return Ok(transportadoras);
                }
            }                               
            

            return NotFound("Não existe transportadoras.");
        }

        [HttpPost]
        [Route("transportadora")]
        public async Task<ActionResult<int>> SaveTransportadora([FromServices] DataContext context, [FromBody] TransportadoraDTO transportadoraDto){

            var informacao = new Informacao() {
                Nome = transportadoraDto.Nome,
                IdInformacao = transportadoraDto.IdInformacao,
                Aniversario = transportadoraDto.Aniversario,
                Email = transportadoraDto.Email,
                Endereco = transportadoraDto.Endereco,
                NumeroContato = transportadoraDto.NumeroContato
            };

            context.Informacaos.Add(informacao);
            await context.SaveChangesAsync();

            var transportadora = new Transportadora() {
                Cnpj = transportadoraDto.Cnpj,
                IdInformacao = informacao.IdInformacao,
                MediaPreco = transportadoraDto.MediaPreco,
                NotaMediaQualidade = transportadoraDto.NotaMediaQualidade,
            };

            context.Transportadoras.Add(transportadora);
            await context.SaveChangesAsync();
            await this._bairroController.SaveBairros(context, transportadora.IdTransportadora, transportadoraDto.Bairros);

            return Ok(transportadora.IdTransportadora);
        }

    }
}
