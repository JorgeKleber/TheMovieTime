using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheMovieTime.Model;
using System.Linq;
using Plugin.Connectivity;

namespace TheMovieTime.Controller.Service
{
    public class ServiceRequest
    {
        private static string _DefaultUrl = "https://api.themoviedb.org/3/movie/upcoming?api_key=";
        private static string _DefaultGenreUrl = "https://api.themoviedb.org/3/genre/movie/list?api_key=";
        private static string _Api_Key = "1f54bd990f1cdfb230adb312546d765d";//"449999e6d231bceb423dc651afa244f9";

        private string language = "&language=pt-BR";
        private string numberPage = "&page=";

        private HttpClient client;

        public ServiceRequest()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<Movie>> LoadData(int count)
        {
            using (Acr.UserDialogs.UserDialogs.Instance.Loading("Carregando..."))
            {
                string url = _DefaultUrl + _Api_Key + language + numberPage + count;

                string urlGenres = _DefaultGenreUrl + _Api_Key + language;

                HttpResponseMessage result = await client.GetAsync(url);
                HttpResponseMessage resultGenres = await client.GetAsync(urlGenres);

                var moviesData = await result.Content.ReadAsStringAsync();
                var genresData = await resultGenres.Content.ReadAsStringAsync();

                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(moviesData);
                RootObjectGenre objectGenre = JsonConvert.DeserializeObject<RootObjectGenre>(genresData);

                ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

                var genres = objectGenre.genres;

                foreach (var item in rootObject.results)
                {
                    Movie movie = new Movie()
                    {
                        backdrop_path = item.backdrop_path,
                        id = item.id,
                        original_language = item.original_language,
                        original_title = item.original_title,
                        overview = item.overview,
                        poster_path = item.poster_path,
                        release_date = item.release_date,
                        title = item.title
                    };

                    string genre = string.Empty;

                    foreach (var ids in item.genre_ids)
                    {
                        var aux = genres.First(g => g.id == ids);
                        genre += aux.name + "  ";
                    }

                    movie.genres = genre;

                    movies.Add(movie);
                }

                return movies;
                
            }
        }

        public async Task<RootFailRequest> GetFailRequest(int count)
        {
            string url = _DefaultUrl + _Api_Key + language + numberPage + count;

            HttpResponseMessage result = await client.GetAsync(url);

            var item = await result.Content.ReadAsStringAsync();

            RootFailRequest rootFail = JsonConvert.DeserializeObject<RootFailRequest>(item);

            return rootFail;
        }

        
    }
}
