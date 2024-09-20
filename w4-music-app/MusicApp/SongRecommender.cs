using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    public enum RecommenderMode {  Random, Wildcard, KnownArtist }


    public abstract class SongRecommender
    {
        protected readonly List<Song> _lib;

        public SongRecommender(IEnumerable<Song> lib)
        {
            this._lib = new List<Song>(lib);
        }

        public abstract Song Suggest(IList<Song> playlist);

    }

    class RandomRecommender : SongRecommender
    {
        public RandomRecommender(IEnumerable<Song> lib) : base(lib) { }

        public override Song Suggest(IList<Song> playlist)
        {
            int randomIndex = new Random().Next(_lib.Count - 1);
            return _lib[randomIndex];
        }
    }
    
    class WildcardRecommender : RandomRecommender
    {
        public WildcardRecommender(IEnumerable<Song> lib) : base(lib) { }

        public override Song Suggest(IList<Song> playlist)
        {
            var s = _lib.FindAll(s => s.Genre == playlist[0].Genre);
            return base.Suggest(s);
        }
    }

    class KnownArtistRecommender : SongRecommender
    {
        public KnownArtistRecommender(IEnumerable<Song> lib) : base(lib) { }

        public override Song Suggest(IList<Song> playlist)
        {
            var myPerformers = playlist.Select(s => s.Perfomer.Name);
            Song s = _lib.Find(s => myPerformers.Contains(s.Perfomer.Name));
            return s;
        }
    }


}
