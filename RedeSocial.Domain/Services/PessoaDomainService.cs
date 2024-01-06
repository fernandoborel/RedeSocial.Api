using RedeSocial.Domain.Dtos;
using RedeSocial.Domain.Helpers;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Domain.Models;

namespace RedeSocial.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de dominio de Pessoa
    /// </summary>
    public class PessoaDomainService : IPessoaDomainService
    {
        //atributo
        private readonly IPessoaRepository _pessoaRepository;

        //método construtor para inicializar os atributos (injeção de dependência)
        public PessoaDomainService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Guid> Criar(CriarPessoaDto dto, string filePath)
        {
            #region Não permitir o cadastro de emails repetidos

            if (await _pessoaRepository.GetAsync(dto.Email) != null)
                throw new ApplicationException("O email informado já está cadastrado.");

            #endregion

            //criando um objeto (modelo de domínio)
            var pessoa = new Pessoa
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = Sha1CryptoHelper.Create(dto.Senha),
                Foto = filePath,
                DataHoraCadastro = DateTime.Now
            };

            //gravar no banco de dados
            await _pessoaRepository.AddAsync(pessoa);

            //retornar o ID da pessoa cadastrada
            return pessoa.Id.Value;
        }

        public async Task<DadosPessoaDto> Autenticar(AutenticarPessoaDto dto)
        {
            //buscar a pessoa no banco de dados através do email e senha
            var pessoa = await _pessoaRepository.GetAsync(dto.Email, Sha1CryptoHelper.Create(dto.Senha));

            #region Acesso negado caso o registro não seja encontrado

            if (pessoa == null)
                throw new ApplicationException("Acesso negado. Usuário inválido.");

            #endregion

            //retornar os dados da pessoa
            var result = new DadosPessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                Foto = pessoa.Foto,
                DataHoraCadastro = pessoa.DataHoraCadastro
            };

            return result;
        }
    }
}