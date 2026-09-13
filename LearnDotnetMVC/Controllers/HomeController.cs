using System.Diagnostics;
using LearnDotnetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnDotnetMVC.Controllers
{
    public class HomeController : Controller
    {
        //The route template looks like this:
        //http://localhost:5190/Home/Index
        //Domain :localhost:5190
        //Controller class name :Home
        //Action method name :Index
        // if we went to add an action (methods in Controller called actions)
        // 1- it must be public
        // 2- it can not be static
        // 3- it can not be overloaded (method overloading is not allowed in MVC)
        // 4- it must return an IActionResult (String , View , HtmlString , Content , File , Json , Redirect , etc.)
        // 5- it must be in a class that inherits from Controller
        //=============================================
        //Action return types 
        //String ==> ContentResult
        //View ==> ViewResult
        //HtmlString ==> HtmlStringResult
        //Content ==> ContentResult
        //File ==> FileResult
        //Json ==> JsonResult
        //Redirect ==> RedirectResult
        //NotFound ==> NotFoundResult
        //Unauthorized ==> UnauthorizedResult
        //Forbidden ==> ForbiddenResult
        //OK ==> OkResult
        //=============================================
        //the url is for action method ShowMessage:
        //http://localhost:5190/Home/ShowMessage
        //output:Hello World from ShowMessage action method
        public string ShowMessage()
        {
            return "Hello World from ShowMessage action method";
        }
        //http://localhost:5190/Home/ShowMessage2
        public ContentResult ShowMessage2()
        {
            //declare result object
            var result = new ContentResult
            {
                //initialize the ContentResult
                Content = "Hello World from ShowMessage2 action method"
            };
            // return the content result
            return result;
        }
        //http://localhost:5190/Home/ShowView
        public ViewResult ShowView()
        {
            //declare result object
            var result = new ViewResult
            {
                // initialize the ContentResult
                // it will search for a view named "View1" in the Views/Home folder
                // and if not found it will search in Views/Shared folder
                // if still not found it will throw an exception
                ViewName = "View1"
            };
            // return the content result
            return result;
        }
        //=========================================================
        // we can send parameter to action method 
        //http://localhost:5190/Home/ShowMix?id=2
        //http://localhost:5190/Home/ShowMix?id=3
        public IActionResult ShowMix(int id)
        {
            if (id % 2 == 0)
                return ShowView();
            else
                return ShowMessage2();
        }
        //=========================================================
        // we can use View () and Content ()methods also that are shorthands for ViewResult and ContentResult
        // Example :
        //http://localhost:5190/Home/ShowMessage3
        public ContentResult ShowMessage3()
        {
            // return the content result
            return Content("Hello World from ShowMessage3 action method");
        }
        //http://localhost:5190/Home/ShowView2
        public ViewResult ShowView2()
        {
            return View("View1");
        }
        //=========================================================
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
