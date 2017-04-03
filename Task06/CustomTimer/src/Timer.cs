using System;
using System.Threading;

namespace CSharpBasics
{
    // delegate defines timer event handler signature
    delegate void OnTimerHandler(int id, int interval);

    // simple custom timer
    class Timer
    {
        int interval;  // service interval in seconds
        int id;        // ID
        DateTime start_time;  // reference time for service interval countdown

        public Timer(int id, int interval)
        {
            this.id = id;
            this.interval = interval;
            start_time = DateTime.Now;
        }

        public event OnTimerHandler Tick;  // timer event

        // process each timer step
        public void OnTick()
        {
            if(Tick != null)
            {
                DateTime current_time = DateTime.Now;
                int seconds = (int)(current_time - start_time).TotalSeconds;

                if (seconds != 0 && seconds % interval == 0)
                {
                    Tick(this.id, this.interval);
                    start_time = current_time;
                }
            }
        }
    }

    // performs timers verification
    class TimerVerification
    {
        public static void Main()
        {
            // setting console window caption text
            Console.Title = "Custom timer verification: press 'Esc' to break";

            // defining two timers with different ID's and intervals
            Timer timer0 = new Timer(1, 10);
            Timer timer1 = new Timer(2, 5);

            // defining subscribers
            Subscriber sb0 = new Subscriber(0, ConsoleColor.Yellow, ConsoleColor.Blue);
            Subscriber sb1 = new Subscriber(1, ConsoleColor.White, ConsoleColor.DarkGreen);
            Subscriber sb2 = new Subscriber(2, ConsoleColor.Black, ConsoleColor.Yellow);

            // subscribing users on different timers
            timer0.Tick += sb0.OnTickHandler;
            timer0.Tick += sb1.OnTickHandler;

            timer1.Tick += sb2.OnTickHandler;

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
