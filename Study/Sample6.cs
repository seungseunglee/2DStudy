using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public partial class T
    {
        public static int v = 5;
        public int v2 = 4;

        // 인스턴스(객체) 상관 없이 최초 1회만 호출!!!
        static T()
        {
            v = 3;
        }

        public T()
        {
        }

        public void Func()
        {
            T.v = 2;
        }

        static void SFunc()
        {
            v = 2; // 하이
        }

    }


    public partial class T
    {
        public void Func2()
        {
        }
    }

    public static class Extend
    {
        public static void Func3(this T t1)
        {
        }

        // 여기서 확장된 기술이 Linq
        public static int Plus(this int t, int value)
        {
            return t + value;
        }
    }


    // Event, lambda, linq ... 다음 기회에
    class Sample6
    {
        static void Main(string[] args)
        {
            int[] a = new int[4];
            int[,] a2 = new int[4, 4];
            List<T> li = new List<T>();
            try
            {
                var v2 = new T();
                var v3 = new T();
            }
            catch (Exception e)
            {

            }
            finally
            {
                var v4 = new T();
            }

            T t1 = new T();
            t1.Func();
            t1.Func3();

            int t = 2;
            int v= t.Plus(3);


            Console.WriteLine(v);
        }
    }
}
