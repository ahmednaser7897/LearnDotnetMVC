using Microsoft.AspNetCore.Mvc;

namespace MVCActionFilter.Controllers;
//we can applay the filter attribute on the controller or on the action or on the global level
//when we applay it on the controller it will execute for all actions in the controller
//when we applay it on the action it will execute only for that action
//to apply the filter on all controllers we can use the
//we can appay it in the program.cs file
// builder.Services.AddControllersWithViews(
//     options => options.Filters.Add(new HandelErorrAttribute())
// );

[HandelErorr]
public class FilterController : Controller
{
    //
    //https://localhost:5130/Filter/Index1 
    //https://localhost:7128/Filter/Index1 
    //[HandelErorr]
    public IActionResult Index1()
    {
        //if we did not used the filter attribute here the error 
        // would be Handled by the built in middleware  
        //and we will get an error page with status code 500
        //but with the filter attribute we will get the error message we defined in the filter
        throw new Exception("Error occurred in the server");
    }
    //[HandelErorr]
    public IActionResult Index2()
    {
        //if we did not used the filter attribute here the error 
        // would be Handled by the built in middleware  
        //and we will get an error page with status code 500
        //but with the filter attribute we will get the error message we defined in the filter
        throw new Exception("Error occurred in the server");
    }
}
