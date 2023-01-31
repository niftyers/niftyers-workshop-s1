using System;
using csharp_foundation;

namespace csharp_foundation
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var Ctrl = new UserController();
            Ctrl.Init();

            Console.WriteLine("Hello World!");
        }
    }
}
