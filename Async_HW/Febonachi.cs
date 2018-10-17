using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_HW
{
    class Febonachi
    {
        private int Digit;

        public Febonachi(int digit) => Digit = digit;

        int Operation()
        {
            Console.WriteLine($"Thread Febonachi - {Thread.CurrentThread.ManagedThreadId}");

            if (Digit == 1)
                return Digit;
            if (Digit == -1)
                return Digit;

            int result = 0, first = 0, second;
            if(Digit > 1)
            {
                second = 1;
                for (int i = 0; i < Digit - 1; i++)
                {
                    result = first + second;
                    first = second;
                    second = result;
                    Thread.Sleep(300);
                }
                return result;
            }
            if (Digit < -1)
            {
                second = -1;
                for (int i = 0; i < Digit - 1; i++)
                {
                    result = first + second;
                    first = second;
                    second = result;
                    Thread.Sleep(300);
                }
                return result;
            }
            return result;
        }

        public void OperationThread()
        {
            Console.WriteLine($"Thread_Febonachi: {Operation()}");
        }


        public async Task<int> OperationAsync() => await Task<int>.Factory.StartNew(Operation);
    }
}
