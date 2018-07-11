using System;
using System.Collections.Generic;
using System.Text;
using TheMovieTime.Controller.Service;
using TheMovieTime.Model;

namespace TheMovieTime.Controller.Util
{
    public class GlobalValue
    {
        public static ServiceRequest serviceRequest { get; set; }
        public static List<Genre> genreList { get; set; }
    }
}
