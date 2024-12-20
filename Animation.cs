using System;
using CsharpFinalProject;

namespace CsharpFinalProject
{
    public class Animation
    {
        public string[] car = {
            "      ______",
            "  ___/      \\___",
            " |   _      _   |",
            "'-(_)-------(_)--'"
        };

        public void ShowCarExit()
        {
            int consoleWidth = Console.WindowWidth;
            int carLength = car[0].Length;
            int maxPosition = consoleWidth - carLength;
            int stopPosition = 100;
            int position = 0;

            while (true)
            {
                Console.Clear();
                foreach (string line in car)
                {
                    Console.SetCursorPosition(position, Console.CursorTop);
                    Console.WriteLine(line);
                }
                Thread.Sleep(10);
                position++;
                if (position > stopPosition)
                {
                    return;
                }
            }
        }

        public void ShowCarReturn()
        {
            int consoleWidth = Console.WindowWidth;
            int carLength = car[0].Length;
            int maxPosition = consoleWidth - carLength;
            int stopPosition = 100;
            int position = stopPosition;

            while (true)
            {
                Console.Clear();
                foreach (string line in car)
                {
                    Console.SetCursorPosition(position, Console.CursorTop);
                    Console.WriteLine(line);
                }
                Thread.Sleep(10);
                position--;
                if (position < 0)
                {
                    return;
                }
            }
        }
    }
}