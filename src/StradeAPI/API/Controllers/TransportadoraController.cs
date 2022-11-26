using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class TransportadoraController : ControllerBase {

        private RegiaoController _regiaoController = new RegiaoController();
        private InformacaoController _informacaoController = new InformacaoController();
        private TipoEncomendaController _tipoEncomendaController = new TipoEncomendaController();

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
                                             
                                             RegioesDto = context.RegiaoTransportadoras.Where(rt => rt.IdTransportadora == trans.IdTransportadora)
                                                                .Select(s => GetEnumDescription((Regiao)s.IdRegiao))
                                                                .ToList(),

                                            TipoEncomendasDto = context.TransportadoraTipoEncomenda.Where(rt => rt.IdTransportadora == trans.IdTransportadora)
                                            .Select(s => GetEnumDescription((TipoEncomenda)s.IdTipo))
                                            .ToList()

                                         }).ToListAsync();
                                         
            if(transportadoras != null && transportadoras.Count > 0) {
                return Ok(transportadoras);
            }

            return NotFound("Não existe transportadoras.");
        }

        [HttpGet]
        [Route("transportadora/regiao/{regiao}")]
        public async Task<ActionResult<List<TransportadoraDTO>>> GetTransportadorasByRegiao([FromServices] DataContext context, [FromRoute] Regiao regiao){

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

            if(transportadoraDto.Senha.Length < 8)
                return NotFound("A senha deve ter no minimo 8 caracteres.");

            var senhaHash = BCrypt.Net.BCrypt.HashPassword(transportadoraDto.Senha);

            var informacao = new InformacaoDTO() {
                Nome = transportadoraDto.Nome,
                IdInformacao = transportadoraDto.IdInformacao,
                Aniversario = transportadoraDto.Aniversario,
                Email = transportadoraDto.Email,
                Endereco = transportadoraDto.Endereco,
                NumeroContato = transportadoraDto.NumeroContato,
                Senha = senhaHash
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
                regioesIndex.Add((Regiao)regiao);

            var tipoEncomendasIndex = new List<TipoEncomenda>();
            foreach(var tipoEncomenda in transportadoraDto.TipoEncomendas)
                tipoEncomendasIndex.Add((TipoEncomenda)tipoEncomenda);

            await this._regiaoController.SaveRegioes(context, transportadora.IdTransportadora, regioesIndex.ToArray());
            await this._tipoEncomendaController.SaveTipoEncomenda(context, tipoEncomendasIndex, idTransportadora.Value);

            return Ok(idTransportadora.Value);
        }

        private static string GetEnumDescription(Enum value)
        {    
            try {

                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (attributes != null && attributes.Any())
                {
                    return attributes.First().Description;
                }

                return value.ToString();

            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return String.Empty;
        }

    }
}