using RationalLib;
using System;

namespace RationalConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(default(int));
            Console.WriteLine(default(string));
            Console.WriteLine(default(BigRational));

            Console.WriteLine(new BigRational(2 , 4));

            var u = BigRational.Parse("3/4");
            Console.WriteLine(u);
        }
    }
}
