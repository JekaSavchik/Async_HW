using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_HW
{
    class Program
    {
        static long Factorial1(int n)
        {
            Console.WriteLine($"Thread Factorial - {Thread.CurrentThread.ManagedThreadId}");
            long result = 1;
            if (n == 0 || n == 1)
                return result;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
                Thread.Sleep(100);
            }

            return result;
        }

        static long Factorial(int x)
        {
            Console.WriteLine($"Thread Factorial - {Thread.CurrentThread.ManagedThreadId}");

            if (x == 0)
                return 1;

            else
                return x * Factorial(x - 1);
        }

        static long Fibonachi(int n)
        {
            Console.WriteLine($"Thread Fibonachi - {Thread.CurrentThread.ManagedThreadId}");

            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            else
                return Fibonachi(n - 1) + Fibonachi(n - 2);
        }

        public delegate long TakesAWhileDelegate(int n);

        static void Main(string[] args)
        {
            TakesAWhileDelegate d1 = Factorial;
            TakesAWhileDelegate d2 = Fibonachi;
            Console.WriteLine($"Thread Main - {Thread.CurrentThread.ManagedThreadId}");

            d1.BeginInvoke(10, TakesAWhileCompleted, d1);
            d2.BeginInvoke(6, TakesAWhileCompleted, d2);
            //for (int i = 0; i < 20; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(100);
            //}

            Console.ReadKey();
        }

        static void TakesAWhileCompleted(IAsyncResult ar)
        {
            if (ar == null) throw new ArgumentNullException("ar");

            TakesAWhileDelegate d1 = ar.AsyncState as TakesAWhileDelegate;
            Trace.Assert(d1 != null, "Invalid object type");

            long result = d1.EndInvoke(ar);
            Console.WriteLine("result: {0}", result);
        }
    }

    #region Metanit
    //public delegate int DisplayHandler(int k);

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine($"Thread Main - {Thread.CurrentThread.ManagedThreadId}");
    //        DisplayHandler handler = new DisplayHandler(Display);

    //        IAsyncResult resultObj = handler.BeginInvoke(10, new AsyncCallback(AsyncCompleted), "Асинхронные вызовы");

    //        Console.WriteLine("Продолжается работа метода Main");

    //        int res = handler.EndInvoke(resultObj);

    //        Console.WriteLine("Результат: {0}", res);

    //        Console.ReadLine();
    //    }

    //    static int Display(int k)
    //    {
    //        Console.WriteLine($"Thread Factorial - {Thread.CurrentThread.ManagedThreadId}");
    //        Console.WriteLine("Начинается работа метода Display....");

    //        int result = 0;
    //        for (int i = 1; i < 10; i++)
    //        {
    //            result += k * i;
    //        }
    //        Thread.Sleep(3000);
    //        Console.WriteLine("Завершается работа метода Display....");
    //        return result;
    //    }

    //    static void AsyncCompleted(IAsyncResult resObj)
    //    {
    //        string mes = (string)resObj.AsyncState;
    //        Console.WriteLine(mes);
    //        Console.WriteLine("Работа асинхронного делегата завершена");
    //    }
    //}
    #endregion
}
