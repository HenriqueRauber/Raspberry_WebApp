using System;
using System.Diagnostics;

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
         
        //private dynamic pyScope = null;

        private PythonMethods()
        {
            //pyRuntime = IronPython.Hosting.Python.CreateRuntime();
            //System.IO.File.Exists(System.IO.Path.Combine(AppContext.BaseDirectory, "Methods.py"))
            //pyScope = pyRuntime.UseFile(System.IO.Path.Combine(AppContext.BaseDirectory, "Methods.py")); 
        }

        public string HelloWorld => Bash("python HelloWorld.py");

        public void PrintHello()
        {
            Bash("python PrintHello.py"); 
        }


        public static string Bash(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }

        public static string BashWin(string cmd)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {cmd}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    //WorkingDirectory = startDir
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}
