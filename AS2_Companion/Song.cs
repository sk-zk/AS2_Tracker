using System.Collections.Generic;
using System.Xml.Serialization;

namespace AS2_Companion
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public List<string> Scores = new List<string>();

        [XmlIgnore] // Ignore the scoreboard during serialization
        public List<Dictionary<string, string>> Scoreboard = new List<Dictionary<string, string>>();

        public static int Count = 0; // Total number of songs loaded

        public string ID = "";
        public string UserID = "";
        public string UserRegion = "";
        public string UserEmail = "";
        public string Mode = "";

        public bool CanPostScore;

        // Construct the song
        public Song()
        {
            //this needs to have no parameters so we can serialize it

            //this.Title = _title;
            //this.AddScore(_score);

            Count++; // Increment song count
        }

        // Song methods
        public void AddScore(string _score)
        {
            this.Scores.Add(_score);
        }

        public void AddScoreboardEntry(Dictionary<string, string> _entry)
        {
            this.Scoreboard.Add(_entry);
        }

        public void SetTitle(string _title)
        {
            this.Title = _title;
        }

        public void SetArtist(string _artist)
        {
            this.Artist = _artist;
        }

        public void SetID(string _id)
        {
            ID = _id;
        }

        public void SetUserID(string _userid)
        {
            UserID = _userid;
        }

        public void SetUserRegion(string _regionid)
        {
            UserRegion = _regionid;
        }

        public void SetUserEmail(string _email)
        {
            UserEmail = _email;
        }

        public void SetMode(string _mode)
        {
            Mode = _mode;
        }

        public void SetCanPost(string _canpost)
        {
            CanPostScore = _canpost == "true";
        }
    }
}
