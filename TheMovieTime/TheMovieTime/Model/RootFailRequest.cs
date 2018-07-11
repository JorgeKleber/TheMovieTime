using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieTime.Model
{
    public class RootFailRequest
    {
        public int status_code { get; set; }
        public string status_message { get; set; }
        public bool success { get; set; }
    }
}
