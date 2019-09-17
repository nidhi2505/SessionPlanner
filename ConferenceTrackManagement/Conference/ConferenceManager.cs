using System.Collections.Generic;

namespace ConferenceTrackManagement
{
    public class ConferenceManager : IConferenceManager
    {
        private readonly IFileReader _fileReader;
        private readonly ITrackPlanner _trackPlanner;
        public ConferenceManager()
        {
            _fileReader = DependencyInjector.Resolve<IFileReader>();
            _trackPlanner = DependencyInjector.Resolve<ITrackPlanner>();
        }

        public List<Track> PlanConference()
        {
            var talkDetails = _fileReader.ReadFile();            
            var planned = _trackPlanner.PlanTracks(talkDetails);
            return planned;
        }       
    }
}
