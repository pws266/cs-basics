using System;
using System.Threading;

namespace CSharpBasics
{
    // timer parameters set passed to event handler
    public class TimerEventArgs : EventArgs
    {
        public int Id;        // ID
        public int Interval;  // timer interval
        public string Name;   // timer name

        public TimerEventArgs(int id, int interval, string name)
        {
            Id = id;
            Interval = interval;
            Name = name;
        }
    }

    // advanced timer based on built-in delegate
    public class AdvancedTimer
    {
        int interval;  // service interval in seconds
        int id;        // ID
        string name;   // timer's name
        DateTime start_time;  // reference time for service interval countdown

        public AdvancedTimer(int id, int interval, string name)
        {
            this.id = id;
            this.interval = interval;
            this.name = name;

            start_time = DateTime.Now;
        }

        public event EventHandler<TimerEventArgs> Tick;  // timer event based on built-in delegate

        // process each timer step
        public void OnTick()
        {
            if(Tick != null)
            {
                DateTime current_time = DateTime.Now;
                int seconds = (int)(current_time - start_time).TotalSeconds;

                if (seconds != 0 && seconds % interval == 0)
                {
                    // creating parameters set for passing to event handler
                    TimerEventArgs traits = new TimerEventArgs(this.id, this.interval, this.name);

                    Tick(this, traits);
                    start_time = current_time;
                }
            }
        }
    }

    class AdvancedTimerVerification
    {
        public static void Main()
        {
            // setting console window caption text
            Console.Title = "Advanced custom timer verification: press 'Esc' to break";

            // defining two timers with different ID's and intervals
            AdvancedTimer timer0 = new AdvancedTimer(1, 10, "Slacker");
            AdvancedTimer timer1 = new AdvancedTimer(2, 5, "Dork");

            // defining subscribers
            AdvancedSubscriber sb0 = new AdvancedSubscriber(0, ConsoleColor.Yellow, ConsoleColor.Blue);
            AdvancedSubscriber sb1 = new AdvancedSubscriber(1, ConsoleColor.White, ConsoleColor.DarkGreen);
            AdvancedSubscriber sb2 = new AdvancedSubscriber(2, ConsoleColor.Black, ConsoleColor.Yellow);

            // subscribing users and methods on different timers
            timer0.Tick += sb0.OnTickHandler;
            timer0.Tick += sb1.OnTickHandler;

            timer0.Tick += sb2.OnTockHandler;

            timer1.Tick += sb2.OnTickHandler;

            timer1.Tick += sb0.OnTockHandler;
            timer1.Tick += sb1.OnTockHandler;

            // starting time tracking: Esc for infinite cycle break
            do {
                timer0.OnTick();
                timer1.OnTick();

                // getting current time 4 times per 1 second
                Thread.Sleep(250);
            } while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
