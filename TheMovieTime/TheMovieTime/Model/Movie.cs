using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieTime.Model
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string genres { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }
}
