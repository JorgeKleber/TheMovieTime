using Android.Content;
using Android.Widget;
using TheMovieTime.Custom;
using TheMovieTime.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer( typeof( MyEntry ), typeof( MyEntryRenderer ) )]
namespace TheMovieTime.Droid.Renderer
{
	public class MyEntryRenderer : EntryRenderer
	{
		public MyEntryRenderer( Context context ) : base( context )
		{

		}

		protected override void OnElementChanged( ElementChangedEventArgs<Xamarin.Forms.Entry> e )
		{
			base.OnElementChanged( e );

			if ( Control != null )
			{
				Control.SetBackgroundResource(Resource.Drawable.shape_edittext);
				Control.SetPadding(20,5,10,5);
				Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.search,0,0,0);
			}
		}
	}
}