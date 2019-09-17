using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConferenceTrackManagement
{
    public class FileReader : IFileReader
    {
        public string FilePath { get; set; }
        private readonly string _filePath;
        public FileReader()
        {
            _filePath = System.Configuration
                      .ConfigurationManager.AppSettings["FilePath"].ToString();
        }
        public Dictionary<string, int> ReadFile()
        {
            var talkDetails = new Dictionary<string, int>();
            var filePath = FilePath ?? _filePath;
            try
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = string.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        var duration = s.Split(' ').Last();
                        var time = 0;
                        var key = s.Substring(0, s.Length - duration.Length - 1);
                        if (IsValidTitle(key))
                        {
                            time = duration.Equals("lightning") ? 5 : Convert.ToInt32(duration.Substring(0, duration.IndexOf("m")));
                            talkDetails.Add(key, time);
                        }

                    }                   
                }
            }
            catch (Exception ex)
            {
                    //log exception
            }
            return talkDetails;
        }

        //validation method can be moved to a separate file
        private bool IsValidTitle(string title)
        {            
            var regex = new Regex("\\d");

                var match = regex.Match(title);
                if (match.Success)
                {
                return false;
                }
            
            return true;
        }
    }
}
