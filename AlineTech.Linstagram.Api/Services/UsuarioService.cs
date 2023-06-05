using AlineTech.Linstagram.Api.Interfaces.Repositories;
using AlineTech.Linstagram.Api.Interfaces.Services;
using AlineTech.Linstagram.Api.Models.Adapters.Requests;
using AlineTech.Linstagram.Api.Models.Adapters.Responses;
using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<(bool success, string message)> AtualizarUsuario(AtualizarUsuarioRequest atualizar)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, string message)> CadastrarUsuario(UsuarioDto usuario)
        {
            var teste = await _usuarioRepository.ObterTodosAsync();

            var user = new Usuario();

            user.NomeCompleto = usuario.NomeCompleto;
            user.Email = usuario.Email;
            user.Senha = usuario.Senha;
            user.DataCadastro = DateTime.Now;
            user.DataAtualizacao = DateTime.Now;
            user.Ativo = true;



            await _usuarioRepository.Inserir(user);

            try
            {
                var save = await _usuarioRepository.SaveChangesAsync();
                if (save)
                {
                    return (true, "Usuário cadastrado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return (false, "*Erro ao cadastrar usuário");
        }

        public async Task<(UsuarioResponse? usuario, string message)> LogarUsuario(string email, string senha)
        {
            var usuario = await _usuarioRepository.BuscarAsync(x => x.Email == email);

            if (usuario.Count() == 0)
            {
                return (null, "Email inválido!");
            }

            var user = usuario.FirstOrDefault(x => x.Senha == senha);

            if (user is null)
            {
                return (null, "Senha inválida!");
            }

            var usuarioReponse = new UsuarioResponse()
            {
                Id = user.Id,
                Email = user.Email,
                NomeCompleto = user.NomeCompleto
            };

            return (usuarioReponse, "");
        }
    }
}
