using ConferenceTrackManagement;
using NUnit.Framework;
using System.IO;

namespace ConferenceTrackManagementTest
{
    [TestFixture]
   public class FileReaderTest
    {
        [Test]
        public void ShouldAddValidTitlesOnly()
        {
            //Arrange 
            var SUT = new FileReader();
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SUT.FilePath = string.Format("{0}\\{1}", directory, "input.txt");
            //Act
            var result = SUT.ReadFile();
            //Assert
            Assert.AreEqual(5, result.Count);
        }
    }
}
