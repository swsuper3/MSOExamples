using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    public class Playlist
    {
        private readonly List<Song> list = new();
        
        public void AddSong(Song s) 
        { 
            list.Add(s); 
        }

        public void Start(SongRecommender rec)
        {
            Console.WriteLine("*Playlist started*");

            foreach (Song s in list)
            {
                s.Play();
            }

            Song recSong = rec.Suggest(list);
            Console.WriteLine("*Playlist finished*");
            recSong.Play();
        }

    }
}

