using Api.Auth;
using Application.Dtos.EmpresaDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EmpresaController : ControllerBase
    {
        private readonly IAdicionarEmpresaService _adicionarEmpresaService;
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IAdicionarEmpresaService adicionarEmpresaService,
            IEmpresaService empresaService)
        {
            _empresaService = empresaService;
            _adicionarEmpresaService = adicionarEmpresaService;
        }
        [HttpPost("/api/AdicionarEmpresa")]
        [AuthCustom("AdicionarEmpresa",AuthenticationSchemes = "Bearer")]
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

                var empresaViewlModel = await _adicionarEmpresaService.AdicionarEmpresaAsync(empresaCreateDto);

                if (empresaViewlModel is null) return BadRequest("Ocorreu um erro interno ao cadastrar a empresa.");

                return Created("Empresa cadastrada com sucesso !", empresaViewlModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/RetornarEmpresaPorId")]
        [AuthCustom("RetornarEmpresaPorId", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> RetornarEmpresaPorId([FromQuery]Guid id)
        {
            try
            {
                var empresaViewDto = await _empresaService.GetEmpresaById(id);

                return Ok(empresaViewDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
