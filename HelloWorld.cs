using System;

namespace CSharp_learning
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // 用 double 计算
            double a = 0.1;
            double b = 0.2;
            double sumDouble = a + b;

            Console.WriteLine("double 计算 0.1 + 0.2 = " + sumDouble);
            Console.WriteLine("double 是否等于 0.3? " + (sumDouble == 0.3));
            Console.WriteLine("double 是否等于 a + b? " + (sumDouble == (a+b)));

            // 用 decimal 计算
            decimal x = 0.1m;
            decimal y = 0.2m;
            decimal sumDecimal = x + y;

            Console.WriteLine("decimal 计算 0.1 + 0.2 = " + sumDecimal);
            Console.WriteLine("decimal 是否等于 0.3m? " + (sumDecimal == 0.3m));

            // 显示 double 的实际存储值（带多位小数）
            Console.WriteLine("double 精确显示: " + sumDouble.ToString("R")); 
            Console.ReadKey();
        }
    }
}
