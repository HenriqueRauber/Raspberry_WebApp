using Microsoft.Scripting.Hosting;
using System; 

namespace Raspberry_WebApp.Python
{
    public class PythonMethods : IPythonMethods
    {
        private static IPythonMethods instancia = null;
        private static readonly object instanciaLock = new object();
        
        public static IPythonMethods GetInstancia()
        {
            lock (instanciaLock)
                if (instancia == null)
                    lock (instanciaLock)
                        instancia = new PythonMethods();
            return instancia;
        }

        private ScriptRuntime pyRuntime = null; 
        private dynamic pyScope = null;

        private PythonMethods()
        {
            pyRuntime = IronPython.Hosting.Python.CreateRuntime();
            //System.IO.File.Exists(System.IO.Path.Combine(AppContext.BaseDirectory, "Methods.py"))
            pyScope = pyRuntime.UseFile(System.IO.Path.Combine(AppContext.BaseDirectory, "Methods.py")); 
        }

        public string HelloWorld => pyScope.HelloWorld();

        public void PrintHello()
        {
            pyScope.PrintHello();
        }
    }
}
