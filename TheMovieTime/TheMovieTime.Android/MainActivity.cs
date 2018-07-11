using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;

namespace TheMovieTime.Droid
{
    [Activity(Label = "TheMovieTime", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Toolbar ToolBar { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(this);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            CrossCurrentActivity.Current.Init(this, bundle);

            LoadApplication(new App(new AndroidInitializer()));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            ToolBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

