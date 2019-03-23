using System; 
using System.Diagnostics; 

namespace Raspberry_WebApp.Python
{
    class PythonMethodsWindows : PythonMethods
    {
        public override string HelloWorld()
        {
            return Bash("python HelloWorld.py");
        }

        public override void PrintHello()
        {
            Bash("python PrintHello.py");
        }
        
        public override string Dir()
        {
            return Bash("Dir");
        }

        private static string Bash(string cmd)
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
