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
        private bool _isBusy;

        public List<Album> Albums
        {
            get => _albums;
            set => SetProperty(ref _albums, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public AlbumsViewModel(IAlbumsApiService albumsApiService)
        {
            _albumsApiService = albumsApiService;
        }

        public override async Task Initialize()
        {
            IsBusy = true;

            var albums = await _albumsApiService.GetAlbumsAsync();

            Albums = albums;

            await base.Initialize();

            IsBusy = false;
        }
    }
}
