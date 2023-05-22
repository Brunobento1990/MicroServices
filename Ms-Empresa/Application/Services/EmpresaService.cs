using Application.Dtos.EmpresaDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using static BCrypt.Net.BCrypt;

namespace Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        const string AdicionarFuncionarioErrorMessage = "Não foi possível adicionar o funcionário admin, tente novamente mais tarde!";
        const string EmpresaCnpjCadastradaErrorMessage = "A empresa com CNPJ : {0}, já se encontra cadastrada em nossa base de dados.";
        const string EmpresaAdicionarErroMessage = "Não foi possível adicionar a empresa: {0}";

        public EmpresaService(IEmpresaRepository empresaRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<EmpresaViewDto> AdicionarEmpresaAsync(EmpresaCreateDto empresaCreateDto)
        {
            if (!await _empresaRepository.ValidarCnpjCadastradoAsync(empresaCreateDto.Cnpj))
                throw new ArgumentException(string.Format(EmpresaCnpjCadastradaErrorMessage, empresaCreateDto.Cnpj));

            var enderecoEmpresa = _mapper.Map<EnderecoEmpresa>(empresaCreateDto.EnderecoEmpresa);
            var contatosEmpresa = _mapper.Map<List<ContatoEmpresa>>(empresaCreateDto.ContatosEmpresa);
            
            var empresa = new Empresa(
                    empresaCreateDto.RazaoSocial,
                    empresaCreateDto.NomeFantasia,
                    empresaCreateDto.Cnpj,
                    empresaCreateDto.Setor,
                    empresaCreateDto.InscricaoEstadual,
                    empresaCreateDto.InscricaoMunicipal
                );

            empresa.EnderecoEmpresa = enderecoEmpresa;
            empresa.ContatosEmpresa = contatosEmpresa;

            var result = await _empresaRepository.AdicionarEmpresaAsync(empresa);

            if (!result) throw new Exception(string.Format(EmpresaAdicionarErroMessage, empresaCreateDto.RazaoSocial));

            var funcionario = new Funcionario();

            var senha = string.Empty;

            for (var i = 0; i < 8; i++)
            {
                var random = new Random();
                int numeroAleatorio = random.Next(10);

                senha += numeroAleatorio.ToString();
            }

            var passwordHash = HashPassword(senha, workFactor: 10);

            funcionario.Senha = passwordHash;
            var firstEmail = empresa.RazaoSocial.Length > 10 ? empresa.RazaoSocial.Substring(0, 9) : empresa.RazaoSocial;
            var secondEmail = empresa.NomeFantasia.Length > 10 ? empresa.NomeFantasia.Substring(0, 9) : empresa.NomeFantasia;

            funcionario.Email = $"{firstEmail}@{secondEmail}.com.br";
            funcionario.Nome = "admin";
            funcionario.EmpresaId = empresa.Id;

            //var addFuncionario = await _funcionarioRepository.AdicionarFuncionarioAsync(funcionario);

            //if (!addFuncionario) throw new Exception(AdicionarFuncionarioErrorMessage);

            //await _unitOfWork.CommitAsync();

            //funcionario.Senha = senha;

            var empresaViewModel = _mapper.Map<EmpresaViewDto>(empresa);

            //empresaViewModel.Funcionario = _mapper.Map<FuncionarioViewModel>(funcionario);
            await _unitOfWork.CommitAsync();

            return empresaViewModel;
        }

    }
}
