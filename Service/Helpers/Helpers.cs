using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Helpers
{
    public static class Helpers
    {
        public static void WriteToConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
