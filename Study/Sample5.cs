using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Sample5
    {
        public class Test
        {
            public Test(string msg)
            {
                Console.WriteLine(msg);
            }
        }

        // 형태만 제공.
        public interface P1
        {
            void Func();
        }

        //public abstract class P1
        //{
            // 상속받으면 함수 만들어주세요.
            // public abstract void Func();

            // public void func2() { }
        //}


        public class Parent : P1
        {
            public int v;
            Test t = new Test("Parent Test");
            public Parent()
            {
                Console.WriteLine("Parent");
            }

            //상속 받은애가 쓸 수 있다!!
            public virtual void Func()
            {
                Console.WriteLine("Im Parent");
            }
        }

        public class Child : Parent
        {
            Test t = new Test("Child Test");
            public Child()
            {
                Console.WriteLine("Child");
            }

            // 위에서 상속받은 함수이다!
            public override void Func()
            {
                Console.WriteLine("Im Child");
            }
        }

        // int v = p?.v ?? 1;
        //int? v2;
        //if (p == null)
        //{
        //    v2 = null;
        //}
        //else
        //{
        //    v2 = p.v;
        //}

        //int v3 = 0;
        //if (v2 == null)
        //{
        //    v3 = 1;
        //}
        //else
        //{
        //    v3 = v2.Value;
        //}

        static void Main(string[] args)
        {
            Child c = new Child();
            Parent p = c;
            p.Func();

            //var p2 = p ?? new Parent();

            //Child c2 = p as Child;
            //c2?.Func();
        }
    }
}
