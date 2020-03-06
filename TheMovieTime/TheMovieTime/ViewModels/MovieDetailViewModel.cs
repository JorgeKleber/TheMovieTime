using Prism.AppModel;
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
    public class MovieDetailViewModel : BindableBase, INavigatedAware, IAutoInitialize
    {
        private Movie itemResult;

        public INavigationService navigationService { get; set; }

        public Movie ItemResult { get => itemResult; set { SetProperty(ref itemResult, value); RaisePropertyChanged("ItemResult"); } }

        public MovieDetailViewModel(INavigationService navigationService) 
        {
            this.navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Device.BeginInvokeOnMainThread( () =>
             {
                 if ( parameters.ContainsKey( "ItemSelecionado" ) )
                 {
                    
                     this.ItemResult = parameters.GetValue<Movie>( "ItemSelecionado" ); 
                 }
             } );
        }
    }
}
