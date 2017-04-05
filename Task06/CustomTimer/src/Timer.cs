namespace CSharpBasics.src
{
    using System;
    using System.Threading;

    // delegate defines timer event handler signature
    public delegate void OnTimerHandler(int id, int interval);

    // simple custom timer
    public class Timer
    {
        int interval;        // service interval in seconds
        int id;              // ID
        DateTime startTime;  // reference time for service interval countdown

        public Timer(int id, int interval)
        {
            this.id = id;
            this.interval = interval;
            startTime = DateTime.Now;
        }

        public event OnTimerHandler Tick;  // timer event

        // process each timer step
        public void OnTick()
        {
            if(Tick != null)
            {
                DateTime currentTime = DateTime.Now;
                int seconds = (int)(currentTime - startTime).TotalSeconds;

                if (seconds != 0 && seconds % interval == 0)
                {
                    Tick(this.id, this.interval);
                    startTime = currentTime;
                }
            }
        }
    }
}
