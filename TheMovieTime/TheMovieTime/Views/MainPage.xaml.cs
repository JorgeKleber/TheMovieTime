using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using TheMovieTime.Custom;
using Xamarin.Forms;

namespace TheMovieTime.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private void CollectionView_Scrolled( object sender, ItemsViewScrolledEventArgs e )
		{
			bool scrollingUp = e.VerticalDelta < 0 ;

			if ( scrollingUp )
			{
				ImageService.Instance.SetPauseWork(true); 
			}
			else
			{
				ImageService.Instance.SetPauseWork(false); 
			}
		}
	}
}