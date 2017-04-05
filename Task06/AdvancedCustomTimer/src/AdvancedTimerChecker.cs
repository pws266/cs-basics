namespace CSharpBasics.src
{
    using System;
    using System.Threading;

    // advanced timer verificator
    public class AdvancedTimerChecker
    {
        public static void Main()
        {
            // setting console window caption text
            Console.Title = "Advanced custom timer verification: press 'Esc' to break";

            // defining two timers with different ID's and intervals
            AdvancedTimer timer0 = new AdvancedTimer(1, 10, "Sleeper");
            AdvancedTimer timer1 = new AdvancedTimer(2, 5, "Dreamer");

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
            do
            {
                timer0.OnTick();
                timer1.OnTick();

                // getting current time 4 times per 1 second
                Thread.Sleep(250);
            } while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

}
