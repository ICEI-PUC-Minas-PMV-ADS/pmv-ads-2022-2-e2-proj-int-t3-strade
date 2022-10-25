using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class BairroController : ControllerBase {
        [HttpPost]
        [Route("bairros/{idTransportadora}")]
        public async Task<ActionResult<bool>> SaveBairros([FromServices] DataContext context, int idTransportadora, [FromBody] List<BairroDTO> bairrosDto){

            var bairros = new List<Bairro>();
            foreach(var bairro in bairrosDto)
                bairros.Add(new Bairro() {
                    IdBairro = bairro.IdBairro,
                    Nome = bairro.Nome,
                    Cep = bairro.Cep,
                });

            context.Bairros.AddRange(bairros);
            await context.SaveChangesAsync();

            var bairrosVinculados = new List<BairroTransportadora>();
            foreach(var bairro in bairros) {
                bairrosVinculados.Add(new BairroTransportadora() { IdTransportadora = idTransportadora,IdBairro = bairro.IdBairro });
            }

            context.BairroTransportadoras.AddRange(bairrosVinculados);
            await context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpGet]
        [Route("bairros")]
        public async Task<ActionResult<List<BairroDTO>>> GetBairros([FromServices] DataContext context){
            var bairros = await context.Bairros.ToListAsync();
            return Ok(bairros.Select(b => new List<BairroDTO>() { 
                new BairroDTO() { 
                    IdBairro = b.IdBairro,
                    Cep = b.Cep,
                    Nome = b.Nome,
            }}));
        }

        [HttpGet]
        [Route("bairros/{idTransportadora}")]
        public async Task<ActionResult<List<BairroDTO>>> GetBairrosTransportadora([FromServices] DataContext context, [FromRoute] int idTransportadora){
            return await (from bairroTransportadora in context.BairroTransportadoras
                                               join bairro in context.Bairros on bairroTransportadora.IdBairro equals bairro.IdBairro
                                               where bairroTransportadora.IdTransportadora == idTransportadora
                                               select new BairroDTO() { 
                                                   
                                                   Cep = bairro.Cep,
                                                   IdBairro = bairro.IdBairro,
                                                   Nome = bairro.Nome
                                                   
                                                }).ToListAsync();
        }
    }
}
