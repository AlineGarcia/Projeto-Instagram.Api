using AlineTech.Linstagram.Api.Interfaces.Services;
using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;
using AlineTech.Linstagram.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlineTech.Linstagram.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        private readonly IPublicacaoService _publicacaoService;

        public PublicacaoController(IPublicacaoService publicacaoService)
        {
            _publicacaoService = publicacaoService;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] PublicacaoDto publicacao)
        {
            var (sucesso, mensagem) = await _publicacaoService.CadastrarPublicacao(publicacao);
            return Ok(mensagem);
        }

        [HttpGet("obter-publicacoes/{perfilId}")]
        public async Task<ActionResult> ObterPublicacao([FromRoute] Guid perfilId)
        {
             var result = await _publicacaoService.ListarPublicacaoUsuario(perfilId);
            return Ok(result);
        }

        [HttpDelete("deletar-publicacao/{publicacaoId}")]
        public async Task<ActionResult> Deletar([FromRoute] Guid publicacaoId)
        {
            var mensagem = await _publicacaoService.DeletarPublicacao(publicacaoId);
            return Ok(mensagem.message);
        }
    }
}
