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

            int c = 0; // 내부적으로 object 만들어서 넣음 -> Boxing
            Boxing(c); // 성능은 안좋다. 다음기회에

            Console.WriteLine("Hello World!");
        }
    }
}
