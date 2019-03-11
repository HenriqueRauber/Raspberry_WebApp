using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Raspberry_WebApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        //https://localhost:xxx/helloWorld
        //https://localhost:xxx/helloWorld/Index
        public IActionResult Index()
        {
            return View();
        }
        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        // GET: /HelloWorld/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        //https://localhost:xxx/helloWorld/Welcome?name=Rick&ID=4
        //https://localhost:xxx/HelloWorld/Welcome/3?name=Rick
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
        //https://localhost:xxx/helloWorld/Welcome?name=Rick&numtimes=4
        ////public string Welcome(string name, int numTimes = 1)
        ////{
        ////    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        ////}
    }
}