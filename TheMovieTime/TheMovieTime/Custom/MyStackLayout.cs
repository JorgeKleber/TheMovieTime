using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace TheMovieTime.Custom
{
    public class MyStackLayout : StackLayout
    {
        //public static readonly BindableProperty ItemTappedCommandProperty =
        //   BindableProperty.Create(nameof(Tapp),
        //                     typeof(ICommand),
        //                     typeof(ListView),
        //                     null);

        #region oldCode
        //public static readonly BindableProperty ItemsProperty =
        //    BindableProperty.Create(nameof(Items), typeof(ObservableCollection<View>),
        //   typeof(BindableStackLayout), null,
        //   propertyChanged: (b, o, n) =>
        //   { 
        //       (n as ObservableCollection<View>).CollectionChanged += (coll, arg) =>
        //       {
        //           switch (arg.Action)
        //           {
        //               case NotifyCollectionChangedAction.Add:
        //                   foreach (var v in arg.NewItems)
        //                       (b as BindableStackLayout).Children.Add((View)v);
        //                   break;
        //               case NotifyCollectionChangedAction.Remove:
        //                   foreach (var v in arg.NewItems)
        //                       (b as BindableStackLayout).Children.Remove((View)v);
        //                   break;
        //               case NotifyCollectionChangedAction.Move:
        //                   //Do your stuff
        //                   break;
        //               case NotifyCollectionChangedAction.Replace:
        //                   //Do your stuff
        //                   break;
        //           }
        //       };
        //   }); 
        #endregion
    }
}
