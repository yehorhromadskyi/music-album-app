using MusicAlbumApp.Core.Models;
using MusicAlbumApp.Core.Services;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAlbumApp.Core.ViewModels
{
    public class AlbumsViewModel : MvxViewModel
    {
        readonly IAlbumsApiService _albumsApiService;

        private List<Album> _albums;

        public List<Album> Albums
        {
            get => _albums;
            set => SetProperty(ref _albums, value);
        }

        public AlbumsViewModel(IAlbumsApiService albumsApiService)
        {
            _albumsApiService = albumsApiService;
        }

        public override async Task Initialize()
        {
            var albums = await _albumsApiService.GetAlbumsAsync();

            Albums = albums;

            await base.Initialize();
        }
    }
}
