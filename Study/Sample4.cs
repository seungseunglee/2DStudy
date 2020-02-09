using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Sample1
    {
        public struct MyStruct
        {
            public int a { get; set; }
        }

        public class MyClass//: object
        {
            public int a { get; set; }
        }

        static void Func(ref MyStruct s)
        {
            s.a = 3;
        }

        // ref 는 참조만 넘기는 느낌
        static void Func2(ref MyClass o)
        {
            o = new MyClass();
            o.a = 3;
        }

        // out은 ref 똑같이 참조를 넘기는 거긴한데,
        // 함수 내에서 변수를 초기화 해준다는 의미
        // out 썼다 -> 그러면 함수 내에서 무조건 변수값을 채워야함
        static void Func3(out MyClass o)
        {
            o = new MyClass();
            //o.a = 3;
        }

        static void Func4(out int o)
        {
            o = 2;
        }

        static void Main(string[] args)
        {
            //var s = new MyStruct();
            //Func(ref s);

            //MyClass o;
            //Func3(out o);

            int t;
            Func4(out t);
            Console.Write(t);

            Console.WriteLine(o.a);
        }
    }
}
