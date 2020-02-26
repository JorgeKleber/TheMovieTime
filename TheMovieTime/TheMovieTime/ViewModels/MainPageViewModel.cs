using Newtonsoft.Json;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using TheMovieTime.Controller.Service;
using TheMovieTime.Controller.Util;
using TheMovieTime.Model;
using Xamarin.Forms;

namespace TheMovieTime.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigatedAware
	{
		private ObservableCollection<Movie> results;
		private ObservableCollection<Movie> carouselList;
		private Movie itemSelecionado;
		private List<Movie> resultsAux;
		private string searchText;
		private bool isRefresing;
		bool isLoading;
		bool isSearch;
		int count = 1;
		public INavigationService navigationService { get; set; }


		public DelegateCommand TesteCommand { get; set; }
		public DelegateCommand SearchCommand { get; set; }
		public DelegateCommand RefreshCommand { get; set; }
		public DelegateCommand<string> TextChanged { get; set; }
		public DelegateCommand TappedCommand { get; set; }
		public DelegateCommand<Movie> InfiniteCommand { get; set; }

		public ObservableCollection<Movie> Results { get => results; set { results = value; RaisePropertyChanged( "Results" ); } }
		public ObservableCollection<Movie> CarouselList { get => carouselList; set { carouselList = value; RaisePropertyChanged( "CarouselList" ); } }

		public string SearchText { get => searchText; set { searchText = value; RaisePropertyChanged( "SearchText" ); } }
		public bool IsRefresing { get => isRefresing; set { isRefresing = value; RaisePropertyChanged( "IsRefresing" ); } }
		public Movie ItemSelecionado { get => itemSelecionado; set { itemSelecionado = value; RaisePropertyChanged( "ItemSelecionado" ); } }

		public MainPageViewModel( INavigationService navigationService )
		{
			//Title = "Movie Time!";

			this.navigationService = navigationService;
			this.resultsAux = new List<Movie>();

			TappedCommand = new DelegateCommand( ItemTapped_Event );
			InfiniteCommand = new DelegateCommand<Movie>( Infinite_Event );
			RefreshCommand = new DelegateCommand( Refresh_Event );
			TextChanged = new DelegateCommand<string>( TextChanged_Event );
		}

		private void Refresh_Event()
		{
			LoadList();

			IsRefresing = false;
		}

		private void TextChanged_Event( string obj )
		{
			isSearch = true;

			var query = resultsAux.Where(r => r.title.ToUpper().Contains(SearchText.ToUpper())).ToList();

			ObservableCollection<Movie> resultQuery = new ObservableCollection<Movie>();

			foreach ( var item in query )
			{
				resultQuery.Add( item );
			}

			Results = resultQuery;

			if ( SearchText.Length == 0 )
			{
				Results = new ObservableCollection<Movie>();

				foreach ( var item in resultsAux )
				{
					Results.Add( item );
				}

				isSearch = false;
			}
		}

		private void Infinite_Event( Movie obj )
		{
			if ( isLoading || Results.Count == 0 )

				return;

			if ( isSearch == false && obj == Results[Results.Count - 1] )
			{
				ReloadList();
			}
		}

		private async void ReloadList()
		{
			if ( CrossConnectivity.Current.IsConnected )
			{
				isLoading = true;

				++count;

				var newItens = await GlobalValue.serviceRequest.LoadData(count);

				foreach ( var item in newItens )
				{
					Results.Add( item );
				}

				resultsAux = Results.ToList();

				isLoading = false;
			}
			else
			{
				await App.Current.MainPage.DisplayAlert( "The Movie Time - Alert", "You offline! :(", "Ok" );
			}
		}

		private async void LoadList()
		{
			if ( CrossConnectivity.Current.IsConnected )
			{
				try
				{
					count = 1;

					Device.BeginInvokeOnMainThread( async () =>
					 {
						 var collection = await GlobalValue.serviceRequest.LoadData( 1 );

						 var colesao = collection.Take<Movie>(3);

						 CarouselList = new ObservableCollection<Movie>();

						 foreach ( var item in colesao )
						 {
							 CarouselList.Add( item );
						 }

						 Results = collection;//await GlobalValue.serviceRequest.LoadData( 1 );

						resultsAux = Results.ToList();
					 } );



				}
				catch ( Exception )
				{
					var erro = await GlobalValue.serviceRequest.GetFailRequest(count);

					await App.Current.MainPage.DisplayAlert( "Atenção", erro.status_message, "Ok" );
				}
			}
			else
			{
				await App.Current.MainPage.DisplayAlert( "The Movie Time - Alert", "You offline! :(", "Ok" );
			}
		}

		private async void ItemTapped_Event()
		{
			var parameter = new NavigationParameters();

			parameter.Add( "Result", ItemSelecionado );

			await this.navigationService.NavigateAsync( "MovieDetail", parameter );
		}

		public void OnNavigatedFrom( INavigationParameters parameters )
		{
			//throw new NotImplementedException();
		}

		public void OnNavigatedTo( INavigationParameters parameters )
		{
			if ( Results == null )
			{
				LoadList();
			}
		}
	}
}
