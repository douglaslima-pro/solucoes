using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Solucoes.Application.DTOs.Erro;
using Solucoes.Domain.Exceptions;

namespace Solucoes.Web.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException ex)
            {
                if (context.HttpContext.Request.Headers.Accept.ToString().Contains(MediaTypeNames.Application.Json))
                {
                    context.HttpContext.Response.StatusCode = 400;

                    var erro = new ErroResultDTO();
                    erro.AdicionarErro(ex.FieldName, ex.Message);

                    context.Result = new JsonResult(erro);
                    context.ExceptionHandled = true;
                }
                else
                {
                    context.HttpContext.Response.StatusCode = 400;
                    context.ModelState.AddModelError(ex.FieldName, ex.Message);
                    context.Result = new ViewResult();
                    context.ExceptionHandled = true;
                }
            }
        }
    }
}
