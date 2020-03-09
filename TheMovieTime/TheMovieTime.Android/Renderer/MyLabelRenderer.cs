using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TheMovieTime.Custom;
using TheMovieTime.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(MyLabel), typeof(MyLabelRenderer))]
namespace TheMovieTime.Droid.Renderer
{
	public class MyLabelRenderer : LabelRenderer
	{
		public MyLabelRenderer( Context context ) : base( context )
		{

		}

		protected override void OnElementChanged( ElementChangedEventArgs<Label> e )
		{
			base.OnElementChanged( e );

			Control.JustificationMode = Android.Text.JustificationMode.InterWord;
		}
	}
}