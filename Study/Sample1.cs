using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Sample1
    {
        // struct, class 차이!
        // C++ -> 사실상 거의 똑같음
        // Java -> class 만!
        // C# -> C/C++, Java랑 섞었어요 
        public struct ABC
        {
            public int a;

            public ABC(int d)
            {
                this.a = d;
            }
        }
        static void func(ABC a)
        {
            a.a = 3;
        }
        static void Main(string[] args)
        {
            ABC abc = new ABC(2);

            func(abc);
            Console.WriteLine(abc.a);
            Console.WriteLine("Hello World!");
        }
    }
}
