using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [ApiController]
    [Route("v1/controller")]
    public class LoginController : ControllerBase {

        [HttpPost]
        [Route("login/transportadora")]
        public async Task<ActionResult<bool>> ValidarLoginTransportadora([FromServices] DataContext context, LoginDTO login){

            if(login is null)
                return Unauthorized(new ResponseError() { IsSuccess = false, Message = "O objeto do login não pode ser nulo"});

            
            if(string.IsNullOrEmpty(login.Email))
                return Unauthorized(new ResponseError() { IsSuccess = false, Message = "O email não pode ser vazio ou nulo."});

            
            if(string.IsNullOrEmpty(login.Senha))
                return Unauthorized(new ResponseError() { IsSuccess = false, Message = "A senha não pode ser vazia ou nula."});

            if(login.Senha.Length < 8)
                return Unauthorized(new ResponseError() { IsSuccess = false, Message = "A senha deve conter pelo menos 8 caracteres."});

            var transportadora = await (from t in context.Transportadoras
                                        join i in context.Informacaos on t.IdInformacao equals i.IdInformacao
                                        where login.Email.Equals(i.Email)
                                        select new {
                                            IdInformacao = i.IdInformacao,
                                            Email = i.Email,
                                            Senha = i.Senha
                                        }).FirstOrDefaultAsync();

            if(transportadora == null || !CompararSenhaHash(login.Senha,transportadora.Senha))
                return Unauthorized(new ResponseError() { IsSuccess = false, Message = "Email ou senha incorretos."});

            return Ok(new ResponseError() { IsSuccess = true, Message = "Credenciais corretas."});
        }

        private static bool CompararSenhaHash(string senha, string hash) {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

    }
}
