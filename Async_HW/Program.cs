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
        static void Main(string[] args)
        {
            int factorial, febonachi;
            Console.WriteLine("Введите число для нахождения его факториала");
            while (!int.TryParse(Console.ReadLine(), out factorial) || factorial <= 0)
                Console.Write("Не корректный ввод. Повторите попытку - ");

            Console.WriteLine("Введите число из ряда Фибоначи");
            while (!int.TryParse(Console.ReadLine(), out febonachi) || febonachi <= 0)
                Console.Write("Не корректный ввод. Повторите попытку - ");


            Factorial Fact = new Factorial(factorial);
            Task<long> tasc1 = Fact.OperationAsync();
            Console.WriteLine($"Thread Main - {Thread.CurrentThread.ManagedThreadId}");
            tasc1.ContinueWith(t => Console.WriteLine($"Async_Factorial: {t.Result}"));

            Febonachi Feb = new Febonachi(febonachi);
            Task<int> tasc2 = Feb.OperationAsync();
            tasc2.ContinueWith(t => Console.WriteLine($"Async_Febonachi : {t.Result}"));

            tasc1.Wait();
            tasc2.Wait();

            Thread myThread = new Thread(new ThreadStart(Fact.OperationThread));
            myThread.Start();

            myThread = new Thread(new ThreadStart(Feb.OperationThread));
            myThread.Start();


            Console.ReadKey();
        }
    }
}
