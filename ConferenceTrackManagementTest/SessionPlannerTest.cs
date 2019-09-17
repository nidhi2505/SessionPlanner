using ConferenceTrackManagement;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceTrackManagementTest
{
    [TestFixture]
    public class SessionPlannerTest
    {
        [Test]
        public void ShouldOnlyPlanMorningSessionFor3hrs()
        {
            //Arrange
            var talks = new Dictionary<string, int>();
            talks.Add("Writing Fast Tests Against Enterprise Rails", 35);
            talks.Add("Overdoing it in Python", 60);
            talks.Add("Common Ruby Errors", 30);
            talks.Add("Rails for Python Developers", 60);
            var SUT = new SessionPlanner();
            //Act
            var result = SUT.PlanSession(talks, true);
            //Assert
            Assert.AreEqual(3, result.Talks.Count);
            Assert.AreEqual("09:00:00", result.Talks.
                       FirstOrDefault(x=>x.Name =="Writing Fast Tests Against Enterprise Rails")
                       .StartTime.ToString("hh:mm:ss"));
            Assert.AreEqual("09:35:00", result.Talks.
                       FirstOrDefault(x => x.Name == "Overdoing it in Python")
                       .StartTime.ToString("hh:mm:ss"));

            Assert.AreEqual("10:35:00", result.Talks.
                       FirstOrDefault(x => x.Name == "Common Ruby Errors")
                       .StartTime.ToString("hh:mm:ss"));


        }

        [Test]
        public void ShouldPlanAfternoonSessionforMax4hrs()
        {
            //Arrange
            var talks = new Dictionary<string, int>();
            talks.Add("Writing Fast Tests Against Enterprise Rails", 25);
            talks.Add("Overdoing it in Python", 60);
            talks.Add("Common Ruby Errors", 30);
            talks.Add("Rails for Python Developers", 60);
            talks.Add("Rails Magic", 5);
            talks.Add("Clojure Ate Scala", 90);
            var SUT = new SessionPlanner();
            //Act
            var result = SUT.PlanSession(talks, false);
            //Assert
            Assert.AreEqual(5, result.Talks.Count);
            Assert.AreEqual("01:00:00 PM", result.Talks.
                      FirstOrDefault(x => x.Name == "Writing Fast Tests Against Enterprise Rails")
                      .StartTime.ToString("hh:mm:ss tt"));
            Assert.AreEqual("01:25:00 PM", result.Talks.
                       FirstOrDefault(x => x.Name == "Overdoing it in Python")
                       .StartTime.ToString("hh:mm:ss tt"));

            Assert.AreEqual("02:25:00 PM", result.Talks.
                       FirstOrDefault(x => x.Name == "Common Ruby Errors")
                       .StartTime.ToString("hh:mm:ss tt"));

            Assert.AreEqual("02:55:00 PM", result.Talks.
                       FirstOrDefault(x => x.Name == "Rails for Python Developers")
                       .StartTime.ToString("hh:mm:ss tt"));

            Assert.AreEqual("03:55:00 PM", result.Talks.
                       FirstOrDefault(x => x.Name == "Rails Magic")
                       .StartTime.ToString("hh:mm:ss tt"));
        }

    }
}
