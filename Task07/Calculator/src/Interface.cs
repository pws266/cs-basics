using System;

namespace CSharpBasics
{
    // auxiliary class for console coloring
    class Interface
    {
        // prints colored message on specified background
        public static void DisplayMessage(string message, ConsoleColor foregroundColor,
                                          ConsoleColor backgroundColor)
        {
            // saving current console settings
            ConsoleColor previousForeground = Console.ForegroundColor;
            ConsoleColor previousBackground = Console.BackgroundColor;

            // setting new console colors
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(message);

            // restoring previous console settings
            Console.ForegroundColor = previousForeground;
            Console.BackgroundColor = previousBackground;
        }
    }
}
