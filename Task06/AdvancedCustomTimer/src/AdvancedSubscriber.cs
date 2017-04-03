using System;

namespace CSharpBasics
{
    // advanced subscriber with different timer event handlers
    public class AdvancedSubscriber
    {
        int id;  // subscriber's ID
        ConsoleColor foreground;  // foreground color for message output
        ConsoleColor background;  // background color for message output

        // displays message in console with specified colors
        void DisplayColoredMessage(string message)
        {
            // saving current console settings
            ConsoleColor previousForeground = Console.ForegroundColor;
            ConsoleColor previousBackground = Console.BackgroundColor;

            // setting new console colors
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            Console.WriteLine(message);

            // restoring previous console settings
            Console.ForegroundColor = previousForeground;
            Console.BackgroundColor = previousBackground;
        }

        public AdvancedSubscriber(int id, ConsoleColor foreground, ConsoleColor background)
        {
            this.id = id;

            this.foreground = foreground;
            this.background = background;
        }

        // event handler for timer
        public void OnTickHandler(object source, TimerEventArgs arg)
        {
            string message = String.Format("{0} > \"OnTickHandler\": timer #{1} with interval {2}s " +
                                           "is expired for subscriber #{3}",
                                           DateTime.Now.ToString("HH:mm:ss"), arg.Id, 
                                           arg.Interval, this.id);
            DisplayColoredMessage(message);
        }

        // another event handler for timer(displays timer's name)
        public void OnTockHandler(object source, TimerEventArgs arg)
        {
            string message = String.Format("{0} > \"OnTockHandler\": timer #{1} with name \"{2}\" " +
                                           "interval {3}s is expired for subscriber #{4}",
                                           DateTime.Now.ToString("HH:mm:ss"), arg.Id, arg.Name,
                                           arg.Interval, this.id);
            DisplayColoredMessage(message);
        }
    }
}
