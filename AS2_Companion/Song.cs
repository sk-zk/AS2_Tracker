using System.Collections.Generic;
using System.Xml.Serialization;

namespace AS2_Companion
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public List<string> Scores = new List<string>();

        [XmlArrayItem("Entry")] //define XML name for the entries
        public List<Scoreboard> Scoreboard = new List<Scoreboard>();

        public static int Count = 0; // Total number of songs loaded

        public string SongID { get; set; }
        public string UserID { get; set; }
        public string UserRegion { get; set; }
        public string UserEmail { get; set; }
        public string Mode { get; set; }
        public bool CanPostScore { get; set; }

        // Construct the song
        public Song()
        {
            //this needs to have no parameters so we can serialize it
            Count++; // Increment song count
        }

        // Song methods
        public void AddScore(string _score)
        {
            this.Scores.Add(_score);
        }

        public void AddScoreboardEntry(Scoreboard _entry)
        {
            this.Scoreboard.Add(_entry);
        }

        public void SetCanPost(string _canpost)
        {
            CanPostScore = _canpost == "true";
        }
    }
}
