using System;

namespace ConferenceTrackManagement
{
    public static class Helper
    {
        //default values to be moved to config file
        public static DateTime EarliestNetworkStartTime => DateTime.Today.Add(new TimeSpan(16, 00, 00));
        public static DateTime LatestNetworkStartTime => DateTime.Today.Add(new TimeSpan(17, 00, 00));
        public static DateTime MorningSessionStartTime => DateTime.Today.Add(new TimeSpan(09, 00, 00));    
        public static DateTime AfternoonSessionStartTime => DateTime.Today.Add(new TimeSpan(13, 00, 00));
        public static DateTime LunchTime => DateTime.Today.Add(new TimeSpan(12, 00, 00));


        public static int GetMorningSessionDuration()
        {
            return (int)LunchTime.Subtract(MorningSessionStartTime).TotalMinutes;
        }
        public static int GetAfternoonSessionDuration()
        {
            return (int)LatestNetworkStartTime.Subtract(AfternoonSessionStartTime).TotalMinutes;
        }

        public static double GetTotalNumberOfhoursTobePlanned()
        {
            return LunchTime.Subtract(MorningSessionStartTime).TotalMinutes
                                     + LatestNetworkStartTime.Subtract(AfternoonSessionStartTime).TotalMinutes;
        }
    }
}
