using MusicAlbumApp.Core.Services;
using MusicAlbumApp.Core.Services.Implementation;
using MusicAlbumApp.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System.Net.Http;

namespace MusicAlbumApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton(new HttpClient());
            Mvx.RegisterType<ISerializationService, SerializationService>();
            Mvx.RegisterType<IAlbumsApiService, AlbumsApiService>();

            // App freezes if there is an asynchronous work 
            // inside Initialize method of the first view model
            // https://github.com/MvvmCross/MvvmCross/issues/2808
            RegisterCustomAppStart<CustomAppStart<AlbumsViewModel>>();
        }
    }
}
