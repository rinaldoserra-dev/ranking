using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RS.Ranking.Catalog.Api.Filters
{
    public class ApiGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _env;
        public ApiGlobalExceptionFilter(IHostEnvironment env)
            => _env = env;
        public void OnException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            var exception = context.Exception;

            if (_env.IsDevelopment())
                details.Extensions.Add("StackTrace", exception.StackTrace);

            details.Title = "An unexpected error ocurred";
            details.Status = StatusCodes.Status422UnprocessableEntity;
            details.Type = "UnexpectedError";
            details.Detail = exception.Message;

            context.HttpContext.Response.StatusCode = (int) details.Status;
            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;

            
        }
    }
}
