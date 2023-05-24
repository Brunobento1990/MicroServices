using Application.Dtos.FuncionarioDtos;
using Application.Interfaces;
using Domain.Interfaces;
using static BCrypt.Net.BCrypt;

namespace Application.Services
{
    public class LoginFuncionarioService : ILoginFuncionarioService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IGerarTokenSerive _gerarTokenService;
        const string ErrorLogin = "E-mail ou senha inválidos!";

        public LoginFuncionarioService(ILoginRepository loginRepository, 
            IGerarTokenSerive gerarTokenService)
        {
            _loginRepository = loginRepository;
            _gerarTokenService = gerarTokenService;
        }

        public async Task<string> LoginAsync(FuncionarioLoginDto funcionarioLoginDto)
        {
            try
            {
                var funcionario = await _loginRepository.LoginAsync(funcionarioLoginDto.Email);

                if (funcionario is null) throw new Exception(ErrorLogin);

                if (!Verify(funcionarioLoginDto.Senha, funcionario.Senha)
                    || !funcionario.Empresa.PagamentoEmDia) throw new Exception(ErrorLogin);

                return _gerarTokenService.GetToken(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
