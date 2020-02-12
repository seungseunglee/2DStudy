using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Sample1
    {
        //struct MyNullable
        //{
        //    int value;
        //    bool isNull;
        //}
        
        static void Func(Nullable<int> a)
        {
        }

        static void Func2(object o)
        {
            Console.WriteLine(o.GetType());
        }

        static void Boxing(object o)
        {
            Console.WriteLine(o.ToString());
        }

        public class ABC //: object
        {
        }

        static void Main(string[] args)
        {
            //object -> class 상속
            ABC b = new ABC();
            Func2(b);

            int? a = null;
            if (a != null)
            {
                Func(a.Value);
            }

            int c = 0;
            Boxing(c);  // 내부적으로 object 만들어서 넣음 -> Boxing
                        // 성능은 안좋다. 다음기회에

                        // 박싱: 값 형식을 참조 형식으로 변환
                        // 언박싱: 참조 형식을 값 형식으로 변환


            Console.WriteLine("Hello World!");
        }
    }
}
