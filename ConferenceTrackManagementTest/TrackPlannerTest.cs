using ConferenceTrackManagement;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceTrackManagementTest
{
    [TestFixture]
    public class TrackPlannerTest
    {
        private readonly Dictionary<string, int> talksforOneDay;
        private readonly Dictionary<string, int> talksforSecondDay;
        public TrackPlannerTest()
        {
            talksforOneDay = new Dictionary<string, int>();
            talksforOneDay.Add("Writing Fast Tests Against Enterprise Rails" ,60);
            talksforOneDay.Add("Overdoing it in Python", 45);
            talksforOneDay.Add("Lua for the Masses", 30);
            talksforOneDay.Add("Ruby Errors from Mismatched Gem Versions", 45);
            talksforOneDay.Add("Common Ruby Errors ", 45);
            talksforOneDay.Add("Rails for Python Developers", 5);
            talksforOneDay.Add("Communicating Over Distance", 60);
            talksforOneDay.Add("Accounting - Driven Development", 45);
            talksforSecondDay = new Dictionary<string, int>();
            talksforSecondDay.Add("Woah", 30);
            talksforSecondDay.Add("Sit Down and Write", 55);
            talksforSecondDay.Add("Pair Programming vs Noise", 45);
            talksforSecondDay.Add("Rails Magic", 60);
            talksforSecondDay.Add("Ruby on Rails: Why We Should Move On", 60);
            talksforSecondDay.Add("Clojure Ate Scala (on my project)", 45);
            talksforSecondDay.Add("Programming in the Boondocks of Seattle", 30);
            talksforSecondDay.Add("Ruby vs. Clojure for Back-End Development", 30);
            talksforSecondDay.Add("Ruby on Rails Legacy App Maintenance", 60);    
        }

        //ShouldStartNetworkEventat4IfEventEndsEarlier

         [Test]
        public void ShouldStartNetworkEventat4IfEventEndsEarlier()
        {
            //Arrange
            DependencyInjector.SetupDI();
            var SUT = new TrackPlanner();
            //Act
            var result = SUT.PlanTracks(talksforOneDay);
            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("04:00 PM", result.Select(z=>z.Networking.StartTime.ToString("hh:mm tt")).FirstOrDefault());
        }

        
        [Test]
        public void ShouldPlanTwoTrackAndStartNetworkEventLatestBy5()
        {
            //Arrange
            DependencyInjector.SetupDI();
            var SUT = new TrackPlanner();
            var talks = talksforOneDay.Union(talksforSecondDay)
                                   .ToDictionary(x=>x.Key , y=>y.Value);
            //Act
            var result = SUT.PlanTracks(talks);
            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("05:00 PM", result.Where(x => x.Title == "Track 1").Select(z => z.Networking.StartTime.ToString("hh:mm tt")).FirstOrDefault());
            Assert.AreEqual("04:00 PM", result.Where(x=>x.Title == "Track 2").Select(z => z.Networking.StartTime.ToString("hh:mm tt")).FirstOrDefault());
        }
    }
}
