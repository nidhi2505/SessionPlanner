using System.Collections.Generic;
using System.Linq;

namespace ConferenceTrackManagement
{
    public class SessionPlanner : ISessionPlanner
    {
        public Session PlanSession(Dictionary<string, int> talks, bool isMorningSession)
        {
            var session = new Session();
            session.Talks = new List<Event>();
           
            try
            {
                var talkStartTime = isMorningSession ? Helper.MorningSessionStartTime : Helper.AfternoonSessionStartTime;
                var maxSessionDuration = isMorningSession ? Helper.GetMorningSessionDuration() : Helper.GetAfternoonSessionDuration();

                foreach (var item in talks)
                {
                    if (session.Talks.Sum(x => x.GetDuration(x.Duration)) < maxSessionDuration &&
                        session.Talks.Sum(x => x.GetDuration(x.Duration)) + item.Value <= maxSessionDuration)
                    {
                        
                            var talkEvent = new Talk();
                            talkEvent.Name = item.Key;
                            talkEvent.Duration = talkEvent.GetDuration(item.Value);
                            talkEvent.StartTime = talkStartTime;
                            session.Talks.Add(talkEvent);
                            talkStartTime = talkStartTime.AddMinutes(talkEvent.GetDuration(item.Value));                        
                       
                    }
                }

            }
            catch (System.Exception ex)
            {
                //log exception
            }
           
     
            return session;
        }
    }
}
