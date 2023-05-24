using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class GerarTokenSerive : IGerarTokenSerive
    {
        private readonly IConfiguration _configuration;

        public GerarTokenSerive(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken(Funcionario funcionario)
        {
            var claims = new[]
                {
                 new Claim("Nome", funcionario.Nome),
                 new Claim("Email", funcionario.Email),
                 new Claim("Id", funcionario.Id.ToString()),
                 new Claim("EmpresaId", funcionario.EmpresaId.ToString()),
                 new Claim("Adicionar", funcionario.Adicionar.ToString()),
                 new Claim("Editar", funcionario.Editar.ToString()),
                 new Claim("Excluir", funcionario.Excluir.ToString()),
                 new Claim("Master", funcionario.Master.ToString()),
                 new Claim("Cnpj", funcionario.Empresa.Cnpj),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            JwtSecurityToken token = new JwtSecurityToken(
              issuer: _configuration["TokenConfiguration:Issuer"],
              audience: _configuration["TokenConfiguration:Audience"],
              claims: claims,
              expires: expiration,
              signingCredentials: credenciais);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
