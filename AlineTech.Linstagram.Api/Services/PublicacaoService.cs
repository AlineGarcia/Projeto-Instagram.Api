using AlineTech.Linstagram.Api.Infra.Repositories;
using AlineTech.Linstagram.Api.Interfaces.Repositories;
using AlineTech.Linstagram.Api.Interfaces.Services;
using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Services
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly IPublicacaoRepository _repository;
        private readonly IPerfilRepository _perfilRepository;

        public PublicacaoService(IPublicacaoRepository repository, IPerfilRepository perfilRepository)
        {
            _repository = repository;
            _perfilRepository = perfilRepository;
        }
        public Task<(bool success, string message)> AtualizarPublicacao(PublicacaoDto publicacaoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, string message)> CadastrarPublicacao(PublicacaoDto publicacaoDto)
        {
            var publicacao = new Publicacao();

            string nameImage = publicacaoDto.Foto?.Substring(0, 23) ?? "";
            string base64 = publicacaoDto.Foto?.Substring(23) ?? "";


            byte[] data = Convert.FromBase64String(base64);

            publicacao.PerfilId = publicacaoDto.PerfilId;
            publicacao.FotoPublicacao = data;
            publicacao.Legenda = publicacaoDto.Legenda;
            publicacao.Arquivar = false;            

            await _repository.Inserir(publicacao);
            var save = await _repository.SaveChangesAsync();

            var perfil = await _perfilRepository.BuscarPorId(publicacaoDto.PerfilId);

            var contagem = await _repository.ObterQuantidadePorPerfilId(publicacaoDto.PerfilId);

            perfil.Publicacoes = contagem;

            await _perfilRepository.Atualizar(perfil);

            var saveUpdate = await _perfilRepository.SaveChangesAsync();

            if (save && saveUpdate)
            {
                return (true, "Publicação cadastrada com sucesso!");
            }

            return (false, "*Erro ao cadastrar publicação");
        }

        public async Task<(bool success, string message)> DeletarPublicacao(Guid id)
        {
            var publicacao = await _repository.GetById(id);

            var perfil = publicacao.Perfil;

            if (perfil is null)
                return (false, "*Perfil da publicação não localizada");

            await _repository.Deletar(id);

            var save = await _repository.SaveChangesAsync();

            if (save == false)
                return (false, "*Falha ao remover publicação!");

            var qtdPublicacoes = await _repository.ObterQuantidadePorPerfilId(perfil.Id);
            perfil.Publicacoes = qtdPublicacoes;

            await _perfilRepository.Atualizar(perfil);

            var saveUpdate = await _perfilRepository.SaveChangesAsync();

            if (saveUpdate == false)
                return (false, "*Falha ao remover publicação!");

            return (true, "Publicação deletada com sucesso!");
        }

        public async Task<List<Publicacao>> ListarPublicacaoFeed(Guid perfilId)
        {
            //var publicacoes = await _repository.ObterPublicacoesComPerfil(perfilId);
            var publicacoes = await _repository.BuscarAsync(x => x.PerfilId != perfilId);
            return publicacoes;
        }

        public async Task<List<Publicacao>> ListarPublicacaoUsuario(Guid perfilId)
        {
            //{
            //    // Define a byte array.
            //    byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            //    Console.WriteLine("The byte array: ");
            //    Console.WriteLine("   {0}\n", BitConverter.ToString(bytes));

            //    // Convert the array to a base 64 string.
            //    string s = Convert.ToBase64String(bytes);
            //    Console.WriteLine("The base 64 string:\n   {0}\n", s);

            //    // Restore the byte array.
            //    byte[] newBytes = Convert.FromBase64String(s);
            //    Console.WriteLine("The restored byte array: ");
            //    Console.WriteLine("   {0}\n", BitConverter.ToString(newBytes));
            //}
            return await _repository.BuscarAsync(x => x.PerfilId == perfilId);
        }
    }
}
