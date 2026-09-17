using Microsoft.AspNetCore.Mvc;

/*
===========================================================
                STATE MANAGEMENT
===========================================================

HTTP is stateless:
Each request is independent from the previous request.

Example:
Request 1 -> Server does not automatically remember the user.
Request 2 -> Server does not automatically know what happened
             in Request 1.

State Management is used to keep data between requests.

The two common ways we use here are:

1. Session
   - Data is stored on the SERVER.
   - The browser keeps a Session ID in a cookie.
   - Good for temporary user data.

2. Cookie
   - Data is stored on the CLIENT (browser).
   - The browser sends the cookie with requests.
   - Good for small pieces of user data.

-----------------------------------------------------------
SESSION SETUP
-----------------------------------------------------------

In Program.cs:

builder.Services.AddSession();

app.UseSession();

-----------------------------------------------------------
COOKIE SETUP
-----------------------------------------------------------

No service is required.
No middleware is required for normal cookies.

===========================================================
*/


namespace DotnetMVCProject.Controllers
{
    public class StateController : Controller
    {
        /*
        ===================================================
                         SESSION
        ===================================================

        Session:
        - Data is stored on the server.
        - The browser has a session cookie that identifies
          the current session.
        - Useful for temporary data between requests.

        Example:

        http://localhost:5074/State/SetSession?name=ahmed&age=22

        http://localhost:5074/State/GetSession
        */

        // Save data in Session
        [HttpGet]
        public IActionResult SetSession(string name, int age)
        {
            // Save data in the server-side session
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetInt32("age", age);

            return Content("Data saved in session");
        }


        // Get data from Session
        [HttpGet]
        public IActionResult GetSession()
        {
            // Get data from the server-side session
            string? name = HttpContext.Session.GetString("name");
            int? age = HttpContext.Session.GetInt32("age");

            return Content(
                $"Name: {name ?? "Not Found"}, Age: {age ?? 0}"
            );
        }


        /*
        ===================================================
                         COOKIES
        ===================================================

        Cookie:
        - Data is stored in the browser (client).
        - The browser sends the cookie back to the server
          with future requests.
        - No AddSession() or UseSession() is required.

        There are two common types:

        1. Session Cookie
           - Normally expires when the browser session ends.

        2. Persistent Cookie
           - Has an expiry date.
           - Can remain after closing the browser.

        Example:

        http://localhost:5074/State/SetCookie?name=fatma&age=32

        http://localhost:5074/State/GetCookie
        */


        // Save data in Cookies
        [HttpGet]
        public IActionResult SetCookie(string name, int age)
        {
            /*
            ------------------------------------------------
            1. SESSION COOKIES
            ------------------------------------------------
            
            No Expires value is specified.

            The browser normally removes them when the
            browser session ends.
            */

            HttpContext.Response.Cookies.Append("name", name);

            HttpContext.Response.Cookies.Append(
                "age",
                age.ToString()
            );


            /*
            ------------------------------------------------
            2. PERSISTENT COOKIES
            ------------------------------------------------

            We specify an expiry date.

            This cookie can remain after closing the browser
            until the expiry date is reached.
            */

            CookieOptions options = new()
            {
                Expires = DateTime.Now.AddDays(1)
            };

            HttpContext.Response.Cookies.Append(
                "persist_name",
                name,
                options
            );

            HttpContext.Response.Cookies.Append(
                "persist_age",
                age.ToString(),
                options
            );

            return Content("Data saved in cookie");
        }


        /*
        ===================================================
                    GET DATA FROM COOKIES
        ===================================================
        */

        // http://localhost:5074/State/GetCookie
        [HttpGet]
        public IActionResult GetCookie()
        {
            // Read data from the browser's cookies

            string name =
                HttpContext.Request.Cookies["name"]
                ?? "Not Found";

            int age =
                int.Parse(
                    HttpContext.Request.Cookies["age"]
                    ?? "0"
                );


            string persistName =
                HttpContext.Request.Cookies["persist_name"]
                ?? "Not Found";

            int persistAge =
                int.Parse(
                    HttpContext.Request.Cookies["persist_age"]
                    ?? "0"
                );


            return Content(
                $"Session Name: {name}, Session Age: {age}\n" +
                $"Persistent Name: {persistName}, " +
                $"Persistent Age: {persistAge}"
            );
        }


        /*
        ===================================================
                    DELETE COOKIES
        ===================================================

        We can delete a cookie using Cookies.Delete().
        */

        // http://localhost:5074/State/DeleteCookie
        [HttpGet]
        public IActionResult DeleteCookie()
        {
            HttpContext.Response.Cookies.Delete("name");
            HttpContext.Response.Cookies.Delete("age");

            HttpContext.Response.Cookies.Delete("persist_name");
            HttpContext.Response.Cookies.Delete("persist_age");

            return Content("Cookies deleted successfully");
        }
    }
}

