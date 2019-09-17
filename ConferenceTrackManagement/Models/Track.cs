namespace ConferenceTrackManagement
{
    public class Track
    {
        public string Title { get; set; }
        public Session MorningSession { get; set; }
        public Session AfternoonSession { get; set; }
        public Lunch Lunch { get; set; }
        public Networking Networking { get; set; }

        public Track()
        {
            Lunch = new Lunch();
            Lunch.Name = "Lunch";
            Lunch.StartTime = Helper.LunchTime;

            Networking = new Networking();
            Networking.Name = "Networking Event";
            MorningSession = new Session();
            AfternoonSession = new Session();
        }

       
    }
}
