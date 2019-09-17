using Autofac;
using System;
using System.Collections.Generic;

namespace ConferenceTrackManagement
{
    public class Program
    {
         static void Main(string[] args)
        {
            DependencyInjector.SetupDI();
            var conferenceManager = new ConferenceManager();
           var planned = conferenceManager.PlanConference();
           

            Print(planned);
            Console.ReadLine();
        }

        private static void Print(List<Track> planned)
        {

            foreach (var track in planned)
            {
                Console.WriteLine(track.Title);
                foreach (var morningSession in track.MorningSession.Talks)
                {
                    var duration = morningSession.Duration == 5 ? "lightning" : $"{morningSession.Duration}min";
                    Console.WriteLine(morningSession.StartTime.ToString("hh:mm tt") + " " + morningSession.Name + " " + duration);
                }
                Console.WriteLine(track.Lunch.StartTime.ToString("hh:mm tt") + " " + track.Lunch.Name);
                foreach (var afternoonSession in track.AfternoonSession.Talks)
                {
                    var duration = afternoonSession.Duration == 5 ? "lightning" : $"{afternoonSession.Duration}min";
                    Console.WriteLine(afternoonSession.StartTime.ToString("hh:mm tt") + " " + afternoonSession.Name + " " + duration);
                }
                Console.WriteLine(track.Networking.StartTime.ToString("hh:mm tt") + " " + track.Networking.Name);
            }
        }
    }
}
