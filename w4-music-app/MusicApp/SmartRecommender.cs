using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    public enum Continent { NorthAmerica, SouthAmerica, Europe, Asia, Africa }

    public class SmartRecommender
    {
        private IEnumerable<Song> _songDB;
        public SmartRecommender(IEnumerable<Song> songDB)
        {
            _songDB = songDB;
        }
        public Tuple<string, string> DoSmartRecommendation(int age, Continent continent)
        {
            //.. smart algorithm
            var selected = _songDB.First(s => s.NrOfPlays > 3);
            return new Tuple<string,string>(selected.Title, selected.Perfomer.Name);
        }

    }

    public class CleverRecommender : SongRecommender
    {
        private SmartRecommender smartRecommender;

        int age;
        Continent continent;

        public CleverRecommender(IEnumerable<Song> songDB, int age, Continent continent) : base(songDB)
        {
            smartRecommender = new SmartRecommender(songDB);
            this.age = age;
            this.continent = continent;
        }

        public override Song Suggest(IList<Song> playlist)
        {
            Tuple<string, string> outputSong = this.smartRecommender.DoSmartRecommendation(age, continent);

            return new Song(outputSong.Item1, new Artist(outputSong.Item2), Genre.None);

        }


    }
}
