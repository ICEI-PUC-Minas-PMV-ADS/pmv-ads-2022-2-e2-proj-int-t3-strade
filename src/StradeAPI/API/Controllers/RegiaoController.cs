using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class RegiaoController : ControllerBase {

        [HttpPost]
        [Route("regioes")]
        public async Task<ActionResult<bool>> SaveRegioes([FromServices] DataContext context, int idTransportadora, Regiao[] regioes){

            var regioesModel = new List<RegiaoTransportadora>();
            foreach(var regiao in regioes) {
                var regiaoModel = await context.RegiaoTransportadoras.FirstOrDefaultAsync(r => r.IdTransportadora == idTransportadora && r.IdRegiao == (int)regiao);
                if(regiaoModel != null) {
                    regioesModel.Add(new RegiaoTransportadora() { IdRegiao = (int)regiao, IdTransportadora = idTransportadora });
                }
            }

            context.AddRange(regioesModel);
            await context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpGet]
        [Route("regioes")]
        public async Task<ActionResult<RegiaoDTO>> GetRegioes([FromServices] DataContext context, int idTransportadora){
            return Ok(await (from r in context.RegiaoTransportadoras
                             where r.IdTransportadora == idTransportadora
                             select new RegiaoDTO() {
                                 IdRegiao = (Regiao)r.IdRegiao,
                                 IdTransportadora = r.IdTransportadora,
                                 IdRegiaoTransportadora = r.IdRegiaoTransportadora
                             }).ToListAsync());
        }

    }
}
