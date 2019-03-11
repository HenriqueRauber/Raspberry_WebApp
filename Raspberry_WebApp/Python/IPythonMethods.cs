using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raspberry_WebApp.Python
{
    public interface IPythonMethods
    {
        string HelloWorld { get; } 
        void PrintHello();
    }
}
