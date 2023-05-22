using Application.Dtos.EmpresaDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }
        [HttpPost("/api/AdicionarEmpresa")]
        public async Task<IActionResult> AdicionarEmpresa([FromBody] EmpresaCreateDto empresaCreateDto)
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

                var empresaViewlModel = await _empresaService.AdicionarEmpresaAsync(empresaCreateDto);

                if (empresaViewlModel is null) return BadRequest("Ocorreu um erro interno ao cadastrar a empresa.");

                return Created("Empresa cadastrada com sucesso !", empresaViewlModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
