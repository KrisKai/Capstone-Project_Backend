using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Data.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace JourneySick.Business.Helpers
{
    public class ExceptionHandlingMiddleware : AuthorizeAttribute
    {
        public RequestDelegate requestDelegate;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessageObject = new ErrorResponse { Message = ex.Message, Code = "500" };
            var statusCode = (int)HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case UserException:
                    errorMessageObject.Code = "U001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case InsertUserException:
                    errorMessageObject.Code = "U002";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case RegisterUserException:
                    errorMessageObject.Code = "R001";
                    statusCode = (int)HttpStatusCode.OK;
                    break;
                case UserAlreadyExistException:
                    errorMessageObject.Code = "U003";
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
