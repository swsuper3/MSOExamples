﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace MusicApp
{
    public class Program
    {
        
        public static async Task Main()
        {
            // load DB
            var songDB = new List<Song>(SongDB.LoadSongDB());

            // Create playlist
            var p = new Playlist();
            p.AddSong(new Song("Crazy what love can do", new Artist("David Guetta"), Genre.Pop));
            p.AddSong(new Song("As it was", new Artist("Harry Styles"), Genre.Pop));
            p.AddSong(new Song("Sonne", new Artist("Rammstein"), Genre.Metal));
            p.AddSong(new Song("Words", new Artist("Alesso"), Genre.Dance));
            p.AddSong(new Song("Snap", new Artist("Rosa Linn"), Genre.Rock));

            // Load preferences
            RecommenderMode recommendMode = RecommenderMode.Random;

            SongRecommender songRecommender;

            switch (recommendMode)
            {
                case RecommenderMode.KnownArtist:
                    songRecommender = new KnownArtistRecommender(songDB);
                    break;
                case RecommenderMode.Random:
                    songRecommender = new RandomRecommender(songDB);
                    break;
                case RecommenderMode.Wildcard:
                    songRecommender = new WildcardRecommender(songDB);
                    break;
                default:
                    songRecommender = new RandomRecommender(songDB);
                    break;
            }


            
            // Start playlist
            p.Start(songRecommender);

            //await Spotify.SearchCodeArtists();
            //await Spotify.SearchPatternTitles();
        }
   

    
    }

    

    
  

    

    

}

