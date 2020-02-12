using DLLTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dllexample
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.Func();
            Console.WriteLine("abc");
        }
    }
}
