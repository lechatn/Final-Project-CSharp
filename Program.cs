using CsharpFinalProject;
using System;

namespace CsharpFinalProject
{
    class Program
    {
        static void Main(string[] str)
        {
            Console.WriteLine("Welcome to the Parking System!");
            Console.WriteLine("You can upgrade the terminal window size to have a better experience");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            new Controller().Start();
        }
    }
}