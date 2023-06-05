using AlineTech.Linstagram.Api.Interfaces.Services;
using AlineTech.Linstagram.Api.Models.Adapters.Requests;
using AlineTech.Linstagram.Api.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlineTech.Linstagram.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService; 

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] UsuarioDto usuario)
        {   
            var (sucesso, mensagem) = await _usuarioService.CadastrarUsuario(usuario);
            return Ok(mensagem);
        }

        [HttpGet("logar")]
        public async Task<ActionResult> Logar([FromQuery] string email, string senha)
        {
            var (usuario, menssage) = await _usuarioService.LogarUsuario(email, senha);

            if (usuario == null)
            {
                return BadRequest(menssage);
            }

            return Ok(usuario);
        }

        [HttpPut("atualizar")]
        public ActionResult Atualizar([FromBody] AtualizarUsuarioRequest atualizarUsuarioRequest)
        {
            var mensagem = _usuarioService.AtualizarUsuario(atualizarUsuarioRequest);

            return Ok(mensagem);
        }
    }
}
