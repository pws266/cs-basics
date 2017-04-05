namespace CSharpBasics.src
{
    using System;

    // timer parameters set passed to event handler
    public class TimerEventArgs : EventArgs
    {
        public int id;        // ID
        public int interval;  // timer interval
        public string name;   // timer name

        public TimerEventArgs(int id, int interval, string name)
        {
            this.id = id;
            this.interval = interval;
            this.name = name;
        }
    }
}
