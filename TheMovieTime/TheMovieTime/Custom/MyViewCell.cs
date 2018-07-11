using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using TheMovieTime.Model;
using Xamarin.Forms;

namespace TheMovieTime.Custom
{
    public class MyViewCell : ViewCell
    {

        public static readonly BindableProperty selectedBackgroundColor =
            BindableProperty.Create("SelectedBackgroundColor",
                                    typeof(Color),
                                    typeof(MyViewCell),
                                    Color.Default);

        public Color SelectedBackgroundColor { get => (Color)GetValue(selectedBackgroundColor); set => SetValue(selectedBackgroundColor, value); }

    }
}
