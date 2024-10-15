using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Babel.Filters
{
    public class ValidateId : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("id", out var idValue) && idValue is int id)
            {
                if (id <= 0)
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        status = StatusCodes.Status400BadRequest,
                        message = "Invalid ID. It must be a positive integer.",
                        timestamp = DateTime.UtcNow,
                    });

                }
            }
            else
            {
                context.Result = new BadRequestObjectResult(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = "ID must be an integer.",
                    timestamp = DateTime.UtcNow,
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
