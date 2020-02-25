using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using TheMovieTime.Model;
using Xamarin.Forms;

namespace TheMovieTime.ViewModels
{
    public class MovieDetailViewModel : BindableBase, INavigatedAware
    {
        private Movie itemResult;

        private string poster_path;
        private string backdrop_path;
        private string overview;
        private string title;
        private string original_title;
        private DateTime release_date;
        private string genre_ids;

        public INavigationService navigationService { get; set; }
        public string Poster_path { get => poster_path; set { poster_path = value; RaisePropertyChanged("Poster_path"); } }
        public string Backdrop_path { get => backdrop_path; set { backdrop_path = value; RaisePropertyChanged("Backdrop_path"); } }
        public string Overview { get => overview; set { overview = value; RaisePropertyChanged("Overview"); } }
        public string Title1 { get => title; set { title = value; RaisePropertyChanged("Title1");} }
        public string Original_title { get => original_title; set => original_title = value; }
        public string Genre_ids { get => genre_ids; set { genre_ids = value; RaisePropertyChanged("Genre_ids"); } }

        public DateTime Release_date { get => release_date; set { release_date = value; RaisePropertyChanged("Release_date"); } }

        public MovieDetailViewModel(INavigationService navigationService) 
        {
            //Title = "Detalhes";
            this.navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (parameters.ContainsKey("Result"))
                {
                    this.itemResult = (Movie)parameters["Result"];

                    Poster_path = this.itemResult.poster_path;
                    Backdrop_path = this.itemResult.backdrop_path;
                    Overview = this.itemResult.overview;
                    Release_date = DateTime.Parse(this.itemResult.release_date);
                    Title1 = this.itemResult.title;
                    Genre_ids = this.itemResult.genres;
                }
            });
        }
    }
}
