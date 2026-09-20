using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCActionFilter.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class CustomExceptionFilterAttribute : Attribute, IFilterMetadata
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        throw new NotImplementedException();
    }

    public void OnException(ExceptionContext context)
    {
        throw new NotImplementedException();
    }
}
