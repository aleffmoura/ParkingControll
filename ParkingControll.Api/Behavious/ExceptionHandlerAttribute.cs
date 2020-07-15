using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingControll.Exceptions;

namespace ParkingControll.Api.Behavious
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Exception = context.Exception;
            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(ExceptionPayload.New(context.Exception));
        }
    }
}
