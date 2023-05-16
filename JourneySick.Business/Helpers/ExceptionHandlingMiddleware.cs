using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.Models.DTOs.CommonDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace JourneySick.Business.Helpers
{
    public class ExceptionHandlingMiddleware : AuthorizeAttribute
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.StackTrace);
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessageObject = new ErrorResponse { Message = ex.Message, Code = "500"};
            var statusCode = (int)HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case UserException:
                    errorMessageObject.Code = "U001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case InsertException:
                    errorMessageObject.Code = "I001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case RegisterUserException:
                    errorMessageObject.Code = "R001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case UserAlreadyExistException:
                    errorMessageObject.Code = "U002";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case LoginFailedException:
                    errorMessageObject.Code = "L001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;                
                case EmptyFieldException:
                    errorMessageObject.Code = "E001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case GetOneException:
                    errorMessageObject.Code = "G001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case UpdateException:
                    errorMessageObject.Code = "U001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case DeleteException:
                    errorMessageObject.Code = "D001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case ValidateException:
                    errorMessageObject.Code = "V001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case PermissionException:
                    errorMessageObject.Code = "P001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                default:
                    errorMessageObject.Code = "500";
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;

            }

            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorMessage);
        }

    }
}
