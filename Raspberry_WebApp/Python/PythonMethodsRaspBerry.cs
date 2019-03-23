using System.Diagnostics;

namespace Raspberry_WebApp.Python
{
    class PythonMethodsRaspBerry : IPythonMethods
    {  
        public string HelloWorld()
        {
            //JSON {"waitingTime": 3, "port": 26, "mode": "OUT"} em Base64: eyJ3YWl0aW5nVGltZSI6IDMsICJwb3J0IjogMjYsICJtb2RlIjogIk9VVCJ9
            return Bash("python python/Led.py eyJ3YWl0aW5nVGltZSI6IDMsICJwb3J0IjogMjYsICJtb2RlIjogIk9VVCJ9");
        }

        public void PrintHello()
        {
            //JOIN {"port": 16, "mode": "IN", "waitingTime": 5} em base64 eyJwb3J0IjogMTYsICJtb2RlIjogIklOIiwgIndhaXRpbmdUaW1lIjogNX0=
            Bash("python python/Button.py eyJwb3J0IjogMTYsICJtb2RlIjogIklOIiwgIndhaXRpbmdUaW1lIjogNX0=");
        }

        public string Dir()
        {
            return Bash("ls");
        }

        private static string Bash(string cmd)
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
