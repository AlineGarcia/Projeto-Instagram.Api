using AlineTech.Linstagram.Api.Interfaces.Repositories;
using AlineTech.Linstagram.Api.Interfaces.Services;
using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;
using AlineTech.Linstagram.Api.Models.Enuns;

namespace AlineTech.Linstagram.Api.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<(bool success, string message)> AlterarTemaPerfil(Guid perfilId)
        {
            var perfil = await _perfilRepository.BuscarPorId(perfilId);

            if (perfil.Tema is null)
            {
                perfil.Tema = ETema.dark.ToString();
            }
            else
            {
                perfil.Tema = perfil.Tema == ETema.dark.ToString() ? ETema.light.ToString() : ETema.dark.ToString();
            }

            await _perfilRepository.Atualizar(perfil);

            var save = await _perfilRepository.SaveChangesAsync();

            if (save)
            {
                return (true, perfil.Tema);
            }

            return (false, "*Erro ao atualizar o tema!");
        }

        public Task<(bool success, string message)> AtualizarPerfil(PerfilDto perfilDto)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, string message)> CadastrarPerfil(PerfilDto perfilDto)
        {
            var nomeUsuario = await _perfilRepository.BuscarAsync(x => x.NomeUsuario == perfilDto.NomeUsuario);

            if (nomeUsuario != null && nomeUsuario.Count() > 0) 
            {
                return (false, "*Nome de usuário já existente!");
            }

            var perfil = new Perfil();

            perfil.UsuarioId = perfilDto.UsuarioId ?? Guid.NewGuid();
            perfil.Foto = perfilDto.FotoPerfil;
            perfil.NomeUsuario = perfilDto.NomeUsuario;
            perfil.Descricao = perfilDto.Descricao;
            perfil.TipoPerfil = perfilDto.TipoPerfil?? 0;


            await _perfilRepository.Inserir(perfil);
            var save = await _perfilRepository.SaveChangesAsync();

            if (save)
            {
                return (true, "Perfil cadastrado com sucesso!");
            }

            return (false, "*Erro ao cadastrar publicação");
        }

        public Task<(bool success, string message)> DeletarPerfil(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Perfil>> ListarPerfilsUsuario(Guid usuarioId)
        {
            var perfils = await _perfilRepository.BuscarAsync(x => x.UsuarioId == usuarioId);
            return perfils.ToList();
        }

        public async Task<Perfil> ObterPerfilUsuario(Guid PerfilId)
        {
            var perfil = await _perfilRepository.BuscarPorId(PerfilId);
            return perfil;
        }
    }
}
