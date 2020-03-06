using Prism;
using Prism.Ioc;
using TheMovieTime.ViewModels;
using TheMovieTime.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using TheMovieTime.Controller.Util;
using Plugin.SharedTransitions;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TheMovieTime
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            GlobalValue.serviceRequest = new Controller.Service.ServiceRequest();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");

            await NavigationService.NavigateAsync($"{nameof(SharedTransitionNavigationPage)}/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SharedTransitionNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<MovieDetail>();
        }
    }
}
