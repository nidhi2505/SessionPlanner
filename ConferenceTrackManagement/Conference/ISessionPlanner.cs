using System.Collections.Generic;

namespace ConferenceTrackManagement
{
    public interface ISessionPlanner
    {
        Session PlanSession(Dictionary<string, int> talks, bool isMorningSession);
    }
}