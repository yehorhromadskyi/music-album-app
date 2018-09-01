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
using MusicAlbumApp.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MusicAlbumApp.Droid.Activities
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class AlbumDetailsActivity : MvxAppCompatActivity<AlbumDetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.album_details);
        }
    }
}