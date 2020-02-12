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
        // struct -> 값 타입으로 스택 메모리에 생성
        // class -> 레퍼런스 타입으로 힙 메모리에 생성
        public class ABC // public struct ABC 로 바꿔 실행하면 func 에서 차이가 생김
        {
            public int a;

            public ABC(int d)
            {
                this.a = d;
            }
        }
        static void func(ABC a) // 실행결과 struct: 2, class: 3
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
