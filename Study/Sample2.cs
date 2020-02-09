using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Sample1
    {
        public class ABC
        {
            // 프로퍼티! 
            // 사실상 함수!
            private int a;
            public int A
            {
                get
                {
                    Console.WriteLine("GeT!");
                    return a;
                }
                set
                {
                    Console.WriteLine("SeT!");
                    a = value;
                }
            }

            // private int _b;
            public int B { get; private set; }

            public int GetA() => a;
        }

        static void Main(string[] args)
        {
            ABC abc = new ABC();
            abc.A = 2;

            abc.B = 2;
            abc.B = -1;
            Console.WriteLine("Hello World!");
        }
    }
}
