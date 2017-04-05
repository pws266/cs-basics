namespace CSharpBasics.src
{
    using System;
    using System.Threading;

    // advanced timer based on built-in delegate
    public class AdvancedTimer
    {
        int interval;  // service interval in seconds
        int id;        // ID
        string name;   // timer's name
        DateTime startTime;  // reference time for service interval countdown

        public AdvancedTimer(int id, int interval, string name)
        {
            this.id = id;
            this.interval = interval;
            this.name = name;

            startTime = DateTime.Now;
        }

        public event EventHandler<TimerEventArgs> Tick;  // timer event based on built-in delegate

        // process each timer step
        public void OnTick()
        {
            if(Tick != null)
            {
                DateTime currentTime = DateTime.Now;
                int seconds = (int)(currentTime - startTime).TotalSeconds;

                if (seconds != 0 && seconds % interval == 0)
                {
                    // creating parameters set for passing to event handler
                    TimerEventArgs traits = new TimerEventArgs(this.id, this.interval, this.name);

                    Tick(this, traits);
                    startTime = currentTime;
                }
            }
        }
    }
}
