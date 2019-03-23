using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Raspberry_WebApp.Python
{

    public abstract class PythonMethods : IPythonMethods
    {
        private static readonly object instanciaLock = new object();
        private static IPythonMethods instancia = null;
        public static IPythonMethods GetInstancia()
        {
            lock (instanciaLock)
                if (instancia == null)
                    lock (instanciaLock)
                    {
                        instancia = RuntimeInformation
                                                .IsOSPlatform(OSPlatform.Windows) ?
                                                new PythonMethodsWindows() as IPythonMethods :
                                                new PythonMethodsRaspBerry() as IPythonMethods;
                    }
            return instancia;
        }
        
        public abstract string HelloWorld();
        public abstract void PrintHello();
        public abstract string Dir();
    } 
}
