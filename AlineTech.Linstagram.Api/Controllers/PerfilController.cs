using AlineTech.Linstagram.Api.Interfaces.Services;
using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;
using AlineTech.Linstagram.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlineTech.Linstagram.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] PerfilDto perfil)
        {
            var (sucesso, mensagem) = await _perfilService.CadastrarPerfil(perfil);
            return Ok(mensagem);
        }

        [HttpGet("obter-por-id/{perfilId}")]
        public async Task<ActionResult> ObterPerfil([FromRoute] Guid perfilId)
        {
            var result = await _perfilService.ObterPerfilUsuario(perfilId);
            return Ok(result);
        }

        [HttpGet("obter-perfils/{usuarioId}")]
        public async Task<ActionResult> ListarPerfils([FromRoute] Guid usuarioId)
        {
            var result = await _perfilService.ListarPerfilsUsuario(usuarioId);
            return Ok(result);
        }
    }
}
