using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCActionFilter.Models;

namespace MVCActionFilter.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class HandelErorrAttribute : Attribute, IExceptionFilter // ==>IExceptionFilter inhert IFilterMetadata
{   //This filter will execute when an exception is thrown in the controller or action
    //it gives us all data we want to know about this request : the exception type,stack trace,request data,ect
    public void OnException(ExceptionContext context)
    {
        //if error is handeled by the action 
        var model = new ErrorViewModel { RequestId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier };
        var view = new ViewResult
        {
            ViewName = "Error",
            StatusCode = StatusCodes.Status500InternalServerError,
            ViewData = new ViewDataDictionary<ErrorViewModel>(
            new EmptyModelMetadataProvider(),
            new ModelStateDictionary())
            {
                Model = model
            }
        };

        context.Result = view;

        // new ContentResult()
        // {
        //     Content = "Sorry , there is an error occurred in the server, try again later",
        //     StatusCode = 500
        // };

    }
}
