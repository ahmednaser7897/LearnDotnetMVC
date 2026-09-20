using DotnetMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMVCProject.Controllers;


public class RouteController : Controller
{
    //URL is a set of
    //1- delimiter : / or . or #
    //2- URL Segment : /home/index
    //==========================================================
    //Segment can be fixed value or variable
    //Fixed value: /Route/index=>>http://localhost:5074/home/index
    //Variable value: /{Controller}/{Name}=>>http://localhost:5074/Route/John
    //==========================================================
    //URL Routing : is a way to define the URL of a web page
    //by defult MVC uses this pattern :
    //http://localhost:5074/{Controller}/{Action}
    // we can override it by using 2ways:
    //1- the [Route] attribute [in Controller , Action , Global Route (appsettings.json)]
    //2- Naming Convention Route(def route with name , pattern , default value) [in the Program.cs]
    //==========================================================================================

    //http://localhost:5074/Route/Methode1?Name=ahmed =>>Default Route
    //http://localhost:5074/M1?Name=sayed =>>Naming Convention Route
    //http://localhost:5074/M1?Name=sayed => this is one segment of the url , 
    // the question mark is the start of the query 
    // string and the equal sign is the start of the value
    // http://localhost:5074/M1/mohamed =>so this will give erorr
    public IActionResult Methode1(string? Name)
    {

        return Content("This is Methode1 : " + Name);

    }
    //http://localhost:5074/Route/Methode2/ahmed/25 =>>Default Route
    //http://localhost:5074/M2/ibrahom/25 =>>Naming Convention Route
    //http://localhost:5074/M2/mona/30 => this is 2 segments of the url , Route and sayed
    //this is called segments not query string
    //http://localhost:5074/M2?Name=sayed&Age=40 =>this will not be found becouse the route pattern 
    //is defined as M2/{Name}/{Age} where age is in range 10 ,30
    //http://localhost:5074/M2/mohamed/20/red =>this will be found becouse the route pattern 
    //is defined as M2/{Name}/{Age}/{color} and color is optional
    public IActionResult Methode2(string? Name, int Age, string color = "Unknown")
    {

        return Content("This is Methode2 : " + Name + " Age : " + Age + " Color : " + color);

    }
    //http://localhost:5074/R/Methode3?name=mohamed =>>>Naming Convention Route
    public IActionResult Methode3(string? Name)
    {

        return Content("This is Methode3 : " + Name);

    }

    //==========================================================================================
    //the [Route] attribute [in Controller , Action , Global Route (appsettings.json)]
    //http://localhost:5074/M4/mohamed/20/red =>this will be found becouse the route pattern 
    //is defined as M4/{Name}/{Age}/{color} and color is optional
    //http://localhost:5074/M4?Name=sayed&Age=40 =>this will not be found becouse the route pattern 
    //is defined as M4/{Name}/{Age}/{color} where age is in range 10 ,20
    //http://localhost:5074/M4/mohamed/20/red =>this will be found becouse the route pattern 
    //is defined as M4/{Name}/{Age}/{color} and color is optional
    [Route("M4/{Name}/{Age:int:range(10,20)}/{color?}", Name = "R4")]
    public IActionResult Methode4(string? Name, int Age, string color = "Unknown")
    {

        return Content("This is Methode4 : " + Name + " Age : " + Age + " Color : " + color);

    }


}
