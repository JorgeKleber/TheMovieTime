using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TheMovieTime.Custom
{
    public class MySearchBar : SearchBar
    {
        public static readonly BindableProperty TextChangedProperty =
            BindableProperty.Create(nameof(TextChangedCommand),
                                    typeof(ICommand),
                                    typeof(MySearchBar),
                                    null);

        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedProperty); }
            set { SetValue(TextChangedProperty, value); }
        }

        public MySearchBar()
        {
            Initializer();
        }

        private void Initializer()
        {
            TextChanged += MySearchBar_TextChanged;
        }

        private void MySearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextChangedCommand != null && TextChangedCommand.CanExecute(null))
                TextChangedCommand.Execute(e.OldTextValue);
        }
    }
}
