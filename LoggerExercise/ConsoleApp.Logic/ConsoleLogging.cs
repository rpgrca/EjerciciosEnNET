using System;

namespace ConsoleApp
{
    public class ConsoleLogging
    {
        public void Log(bool message, bool warning, bool error, string l)
        {
            if (message)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(l);
                Console.ResetColor();
            }

            if (warning)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(l);
                Console.ResetColor();
            }

            if (error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(l);
                Console.ResetColor();
            }
        }
    }
}