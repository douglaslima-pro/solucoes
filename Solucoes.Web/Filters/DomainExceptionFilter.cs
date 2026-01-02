using Microsoft.AspNetCore.Mvc.Filters;
using Solucoes.Domain.Exceptions;

namespace Solucoes.Web.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException ex)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.ModelState.AddModelError(string.Empty, ex.Message);
                context.ExceptionHandled = true;
            }
        }
    }
}
