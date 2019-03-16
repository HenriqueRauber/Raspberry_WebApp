using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raspberry_WebApp.Python;

//using MadeInTheUSB;
//using MadeInTheUSB.GPIO;
using System.Diagnostics;

namespace Raspberry_WebApp.Controllers
{
    public class HelloWorldController : Controller
    { 
        //https://localhost:xxx/helloWorld
        //https://localhost:xxx/helloWorld/Index
        //GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        } 

        //GET: /HelloWorld/Welcome/  
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }

        // Ajax POST: /HelloWorld/HelloWorld/
        [HttpPost]
        public ActionResult HelloWorld()
        {
            try
            { 
                return Content(PythonMethods.GetInstancia().HelloWorld);
            }
            catch (Exception e)
            {
                return Content($"Ocorreu um erro: {e.ToString()}");
            }
        }
         
        // Ajax POST: /HelloWorld/PrintHello/
        [HttpPost]
        public ActionResult PrintHello()
        {
            try
            {
                PythonMethods.GetInstancia().PrintHello(); 
            }
            catch(Exception e)
            {
                return Content($"Ocorreu um erro: {e.ToString()}");
            }

            return Content("Ok");
        }

    }
}