using System.Collections.Generic;

namespace ConferenceTrackManagement
{
    public interface ITrackPlanner
    {
        List<Track> PlanTracks(Dictionary<string, int> talks);
    }
}