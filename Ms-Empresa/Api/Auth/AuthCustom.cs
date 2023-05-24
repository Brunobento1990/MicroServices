using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Auth
{
    public class AuthCustom : AuthorizeAttribute, IAuthorizationFilter
    {
        private string _action;

        public AuthCustom(string action)
        {
            _action = action;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var permissaoAdicionar = bool.Parse(context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Adicionar")?.Value);
            var permissaoAdicionarEmpresa = bool.Parse(context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Master")?.Value);

            if (!permissaoAdicionar && _action == "Adicionar") context.Result = new UnauthorizedResult();
            if (!permissaoAdicionarEmpresa && _action == "AdicionarEmpresa") context.Result = new UnauthorizedResult();
        }
    }
}
