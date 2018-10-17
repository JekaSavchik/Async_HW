using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_HW
{
    class Factorial
    {
        private int Digit;

        public Factorial(int digit) => Digit = digit;

        long Operation()
        {
            Console.WriteLine($"Thread Factorial - {Thread.CurrentThread.ManagedThreadId}");
            if (Digit == 0)
                return 1;
            long result = 1;
            for (int i = 1; i <= Digit; i++)
            {
                result *= i;
                Thread.Sleep(300);
            }
            return result;
        }

        public void OperationThread()
        {
            Console.WriteLine($"Thread_Factorial: {Operation()}");
        }

        public async Task<long> OperationAsync() => await Task<long>.Factory.StartNew(Operation);
    }
}
