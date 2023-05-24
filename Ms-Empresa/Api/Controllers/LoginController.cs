using Application.Dtos.FuncionarioDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ILoginFuncionarioService _loginFuncionarioService;

        public LoginController(ILoginFuncionarioService loginFuncionarioService)
        {
            _loginFuncionarioService = loginFuncionarioService;
        }

        [HttpPost("/api/Login")]
        public async Task<IActionResult> Login([FromBody] FuncionarioLoginDto funcionarioLoginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    var message = string.Join("\n", errors);
                    return BadRequest(message);
                }

                var token = await _loginFuncionarioService.LoginAsync(funcionarioLoginDto);

                if (token == null) return BadRequest();

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
