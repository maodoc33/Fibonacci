using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fibonacci
{
    internal class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = Fibonacci(30);
            stopWatch.Stop();
            Console.WriteLine("Fibonacci 30=" + result + " RunTime Fibonacci: " + stopWatch.ElapsedTicks);

            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            result = FibonacciMemo(30);
            stopWatch2.Stop();
            Console.WriteLine("Fibonacci 30=" + result + " RunTime FibonacciMemo: " + stopWatch2.ElapsedTicks);

            Stopwatch stopWatch3 = new Stopwatch();
            stopWatch3.Start();
            result = FibonacciBottomUp(30);
            stopWatch3.Stop();
            Console.WriteLine("Fibonacci 30=" + result + " RunTime FibonacciBottomUp: " + stopWatch3.ElapsedTicks);
            Console.ReadLine();
        }

        /// <summary>
        /// Recursive Fibonacci
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long Fibonacci(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private static readonly Dictionary<int, long> cache = new Dictionary<int, long>() { { 0, 1 }, { 1, 1 } };

        /// <summary>
        /// Fibonacci with Memoization
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long FibonacciMemo(int n)
        {
            // These values are now in the cache
            //if (n == 0) return 1;
            //if (n == 1) return 1;

            if (cache.ContainsKey(n))
                return cache[n];


            var result = FibonacciMemo(n - 1) + FibonacciMemo(n - 2);
            cache[n] = result;
            return result;
        }

        /// <summary>
        /// Fibonacci BottomUp approach
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long FibonacciBottomUp(int n)
        {
            var a = 1; // fib(n-2)
            var b = 1; // fib(n-1)
            for (int i = 2; i < n + 1; i++)
            {
                var temp = a;
                a = b;
                b = temp + b;
            }

            return b;
        }
    }
}
