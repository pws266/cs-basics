namespace CSharpBasics.src
{
    using System;

    // subscriber for custom timer usage
    public class Subscriber
    {
        int id;  // subscriber's ID
        ConsoleColor foreground;  // foreground color for message output
        ConsoleColor background;  // background color for message output

        public Subscriber(int id, ConsoleColor foreground, ConsoleColor background)
        {
            this.id = id;

            this.foreground = foreground;
            this.background = background;
        }

        // event handler for timer with specified ID and interval in seconds
        public void OnTickHandler(int id, int interval)
        {
            // saving current console settings
            ConsoleColor previousForeground = Console.ForegroundColor;
            ConsoleColor previousBackground = Console.BackgroundColor;

            // setting new console colors
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            Console.WriteLine("{0} > timer #{1} with interval {2} s is expired for subscriber #{3}", 
                              DateTime.Now.ToString("HH:mm:ss"), id, interval, this.id);

            // restoring previous console settings
            Console.ForegroundColor = previousForeground;
            Console.BackgroundColor = previousBackground;
        }
    }
}
