using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RedeSocial.Api.Models;
using System.Net;

namespace RedeSocial.Api.Middlewares
{
    /// <summary>
    /// Middleware para tratamento global de exceções do projeto
    /// </summary>
    public class ExceptionMiddleware
    {
        /// <summary>
        /// Capturar informações sobre a requisição HTTP realizada na API
        /// </summary>
        private readonly RequestDelegate? _requestDelegate;

        public ExceptionMiddleware(RequestDelegate? requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        /// <summary>
        /// Método para capturar as requisições e respostas da API
        /// </summary>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                //executando a requisição
                await _requestDelegate(httpContext);
            }
            catch (ApplicationException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        /// <summary>
        /// Método para realizar o tratamento das exceções no Middleware
        /// </summary>
        public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors = new List<string>();

            switch (exception)
            {
                case ApplicationException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorViewModel.Errors.Add(exception.Message);
                    break;

                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorViewModel.Errors.Add("Ocorreu um erro interno, entre em contato com o nosso suporte.");
                    break;
            }

            errorViewModel.HttpStatus = httpContext.Response.StatusCode;
            httpContext.Response.ContentType = "application/json";

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorViewModel, settings));
        }
    }
}