using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class TransportadoraController : ControllerBase {

        private RegiaoController _regiaoController;
        private InformacaoController _informacaoController = new InformacaoController();

        public TransportadoraController () {
            _regiaoController = new RegiaoController();
        }

        [HttpGet]
        [Route("transportadora")]
        public async Task<ActionResult<List<TransportadoraDTO>>> GetTransportadoras([FromServices] DataContext context){

            var transportadoras = await (from trans in context.Transportadoras
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
                                             
                                             Regioes = context.RegiaoTransportadoras.Where(rt => rt.IdTransportadora == trans.IdTransportadora)
                                                                .Select(s => new RegiaoDTO() {
                                                                    IdTransportadora = s.IdTransportadora,
                                                                    IdRegiao = (Regiao)s.IdRegiao,
                                                                    IdRegiaoTransportadora = s.IdRegiaoTransportadora })
                                                                .ToList()

                                         }).ToListAsync();
                                         
            if(transportadoras != null && transportadoras.Count > 0) {
                return Ok(transportadoras);
            }

            return NotFound("Não existe transportadoras.");
        }

        [HttpGet]
        [Route("transportadora/cep/{cep}")]
        public async Task<ActionResult<List<TransportadoraDTO>>> GetTransportadorasByCEP([FromServices] DataContext context, [FromRoute] Regiao regiao){

                var transportadoras = await (from trans in context.Transportadoras

                                         join reg in context.RegiaoTransportadoras on trans.IdTransportadora equals reg.IdTransportadora
                                         where reg.IdRegiao == (int)regiao

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
            

            return NotFound("Não existe transportadoras.");
        }

        [HttpPost]
        [Route("transportadora")]
        public async Task<ActionResult<int>> SaveTransportadora([FromServices] DataContext context, [FromBody] TransportadoraDTO transportadoraDto){

            if(transportadoraDto == null)
                return NotFound("Transportadora DTO inválida.");

            var informacao = new InformacaoDTO() {
                Nome = transportadoraDto.Nome,
                IdInformacao = transportadoraDto.IdInformacao,
                Aniversario = transportadoraDto.Aniversario,
                Email = transportadoraDto.Email,
                Endereco = transportadoraDto.Endereco,
                NumeroContato = transportadoraDto.NumeroContato
            };

            var idTransportadora = await _informacaoController.SaveInformacao(context, informacao);

            var transportadora = new Transportadora() {
                Cnpj = transportadoraDto.Cnpj,
                IdInformacao = idTransportadora.Value,
                MediaPreco = transportadoraDto.MediaPreco,
                NotaMediaQualidade = transportadoraDto.NotaMediaQualidade,
            };

            context.Transportadoras.Add(transportadora);

            await context.SaveChangesAsync();

            var regioesIndex = new List<Regiao>();
            foreach(var regiao in transportadoraDto.Regioes)
                regioesIndex.Add(regiao.IdRegiao);

            await this._regiaoController.SaveRegioes(context, transportadora.IdTransportadora, regioesIndex.ToArray());

            return Ok(transportadora.IdTransportadora);
        }

    }
}