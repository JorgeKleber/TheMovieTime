using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TheMovieTime.Custom
{
    public class MyListView : ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
           BindableProperty.Create(nameof(ItemTappedCommand),
                             typeof(ICommand),
                             typeof(ListView),
                             null);

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        public static readonly BindableProperty ItemAppearingCommandProperty =
            BindableProperty.Create(nameof(ItemAppearingCommand),
                                typeof(ICommand),
                                typeof(ListView),
                                null);

        public ICommand ItemAppearingCommand
        {
            get { return (ICommand)GetValue(ItemAppearingCommandProperty); }
            set { SetValue(ItemAppearingCommandProperty, value); }
        }

        public MyListView()
            : base()
        {
            Initialize();
        }
        public MyListView(ListViewCachingStrategy cachingStrategy)
            : base(cachingStrategy)
        {
            Initialize();
        }

        private void Initialize()
        {
            ItemTapped += ListView_ItemTapped;
            ItemAppearing += MyListView_ItemAppearing;
        }

        private void MyListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (ItemAppearingCommand != null && ItemAppearingCommand.CanExecute(null))
                ItemAppearingCommand.Execute(e.Item);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ItemTappedCommand != null && ItemTappedCommand.CanExecute(null))
                ItemTappedCommand.Execute(e.Item);
        }
    }
}
