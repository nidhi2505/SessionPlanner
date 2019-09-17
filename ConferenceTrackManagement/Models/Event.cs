using System;

namespace ConferenceTrackManagement
{
    public abstract class Event
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }

        public abstract int GetDuration(int duration);
    }
}
