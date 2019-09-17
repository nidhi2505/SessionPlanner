using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceTrackManagement
{
    public class TrackPlanner : ITrackPlanner
    {   
        private Dictionary<string, int> talksToBePlanned;
        private readonly ISessionPlanner _sessionPlanner;
        public TrackPlanner()
        {
            _sessionPlanner = DependencyInjector.Resolve<ISessionPlanner>();
        }
        public List<Track> PlanTracks(Dictionary<string, int> talks)
        {
            var tracks = new List<Track>();
            try
            {
                var totalDurationOfTalks = talks.Sum(x => x.Value);
                var numberOfTracksToBePlanned = Math.Ceiling(totalDurationOfTalks / Helper.GetTotalNumberOfhoursTobePlanned());
                talksToBePlanned = talks;

                for (int i = 1; i <= numberOfTracksToBePlanned; i++)
                {
                    var title = $"Track {i}";
                    var track = PlanSingleTrack(talksToBePlanned, title);
                    tracks.Add(track);
                }
            }
            catch (Exception ex)
            {
                // log exception
            }

            return tracks;
        }
     

        private Track PlanSingleTrack(Dictionary<string,int> talks, string trackName)
        {
            var track = new Track();
            track.Title = trackName;
            var morningSession = _sessionPlanner.PlanSession(talks,true);
            var leftoverTalks = talks.Where(x =>!morningSession.Talks.Any(y => y.Name == x.Key))
                                  .ToDictionary(z => z.Key, z => z.Value);
            var afternoonSession = _sessionPlanner.PlanSession(leftoverTalks, false);
          
            talksToBePlanned = leftoverTalks.Where(x => !afternoonSession.Talks.Any(y => y.Name == x.Key))
                                                                    .ToDictionary(z=>z.Key,z=>z.Value);
            track.MorningSession = morningSession;
           
            track.AfternoonSession = afternoonSession;
            var lasttalk = track.AfternoonSession.Talks.Max(x => x.StartTime);
            var duration = track.AfternoonSession.Talks.Where(x => x.StartTime == lasttalk).Select(x => x.Duration).FirstOrDefault();
            track.Networking.StartTime = lasttalk.AddMinutes(duration) < Helper.EarliestNetworkStartTime ?
                                            Helper.EarliestNetworkStartTime : lasttalk.AddMinutes(duration);

            return track;
        }
    }
}
