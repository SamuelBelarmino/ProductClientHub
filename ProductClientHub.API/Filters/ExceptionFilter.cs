using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;
using System.Net;

namespace ProductClientHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ProductClientHubException productClientHubException) 
            {
                context.HttpContext.Response.StatusCode = (int)productClientHubException.GetStatusCode();
               
                context.Result = new ObjectResult(new ResponseErrorMensagesJson(productClientHubException.GetErrors()));
            }
            else
            {
                ThrowUnknownError(context);
            }
        }

        private void ThrowUnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            //context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(new ResponseErrorMensagesJson("Erro desconhecido"));

        }
    }
}
