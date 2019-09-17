using System.Collections.Generic;

namespace ConferenceTrackManagement
{
    public interface IFileReader
    {
        Dictionary<string, int> ReadFile();
    }
}