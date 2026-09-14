using DotnetMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMVCProject.Controllers;


public class BindController : Controller
{
    // Data Binding -Bind Parameters From Request To Action Method Parameters
    // it search for the key in 3 places by order
    //      1- Form Data (api body)
    //      2- Route Values (in the api path)
    //      3- Query String (api parameters)

    //==========================================================================================
    //It has many types:
    //1-Primitive Types
    //      1- if we added more than one value for the same parameter, it will take the first value
    //         Eg: http://localhost:5074/Bind/TetsPrimitiveType?name=John&age=25&name=Doe&age=30
    //         Output: name: John, age: 25
    //      2- if we added value that is not exist in the param list it will not cause an error instead it will take default value
    //         Eg: http://localhost:5074/Bind/TetsPrimitiveType?name=John&age=25&Weight=70
    //         it will ignore the extra value 
    //      3- if it did not find the value for a parameter in the request it will take the default value
    //         Eg: http://localhost:5074/Bind/TetsPrimitiveType?name=John
    //         Output: name: John, age: 0
    //      4- if we have a param called id we can pass it in the url without ?
    //         values like this is called [Route Values]
    //         Eg: http://localhost:5074/Bind/TetsPrimitiveType/1?name=John&age=25
    //         Output: name: John, age: 25
    //http://localhost:5074/Bind/TetsPrimitiveType/1?name=John&age=25
    public IActionResult TetsPrimitiveType(string name, int age, int id)
    {
        Console.WriteLine("name: " + name);
        Console.WriteLine("age: " + age);
        Console.WriteLine("id: " + id);
        return Content("name: " + name + " age: " + age + " id: " + id);

    }
    //==========================================================================================
    // 2- Array and collection Parameter
    //      1- if we have more than one value for the same parameter it will take all values
    //          http://localhost:5074/Bind/TestArrayParameter?names=John&names=Doe&ages=25&ages=30
    //      2-  we can use it with comma separated values 
    //          http://localhost:5074/Bind/TestArrayParameter?names=John,Doe,John&ages=25,30,35
    //      3-we can use index
    //          http://localhost:5074/Bind/TestArrayParameter?names[0]=John&names[1]=Doe&ages[0]=25&ages[1]=30
    //http://localhost:5074/Bind/TestArrayParameter?names=John&names=Doe&ages=25&ages=30
    public IActionResult TestArrayParameter(string[] names, int[] ages)
    {
        Console.WriteLine("names: " + string.Join(", ", names));
        Console.WriteLine("ages: " + string.Join(", ", ages));
        return Content("names: " + string.Join(", ", names) + " ages: " + string.Join(", ", ages));
    }
    //==========================================================================================
    // 3- Dictionary Parameter
    //      1- if we have more than one value for the same parameter it will take all values
    //          Eg: http://localhost:5074/Bind/TestDictionaryParameter?dict[key1]=1&dict[key2]=2
    //          Output: dict: key1: 1, key2: 2
    //http://localhost:5074/Bind/TestDictionaryParameter?dict[key1]=1&dict[key2]=2
    public IActionResult TestDictionaryParameter(Dictionary<string, int> dict)
    {
        Console.WriteLine("dict: " + string.Join(", ", dict));
        return Content("dict: " + string.Join(", ", dict));
    }
    //==========================================================================================
    //4-  Complex Object Parameters
    //    1- to pass data we pass all the dept attributes in the url
    //       http://localhost:5074/Bind/TestObjectParameters?Id=1&Name=John&ManagerName=Doe
    //    2- its not case sensitive 
    //       http://localhost:5074/Bind/TestObjectParameters?name=John&nd=1&managername=Doe
    //    3- if we forget an attribute in the url, it will take the default value
    //       Eg: http://localhost:5074/Bind/TestObjectParameters?name=John&nd=1&managername=Doe
    //       Output: department info ==> Id: 0, Name: John, ManagerName: Doe
    //    4- if a key that is not in the model attributes it will ignore it
    //       Eg: http://localhost:5074/Bind/TestObjectParameters?name=John&nd=1&managername=Doe&day=Monday
    //       Output: department info ==> Id: 0, Name: John, ManagerName: Doe

    public IActionResult TestObjectParameters(Department department)
    {
        Console.WriteLine(department);
        return Content(department.ToString());
    }
    //==========================================================================================
    // finaly if in the view we set the form as POST the action will recive the data from the body 
    // instead of the url (query string)
    // and if we set it as GET the action will recive the data from the url (query string)
    // so if using get:http://localhost:5074/Bind/TestObjectParameters?name=John&nd=1&managername=Doe
    // if using post:http://localhost:5074/Bind/TestObjectParameters
    // and data will be recived from Form body not url in post
}
