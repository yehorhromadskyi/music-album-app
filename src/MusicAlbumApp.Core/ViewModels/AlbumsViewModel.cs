using MusicAlbumApp.Core.Models;
using MusicAlbumApp.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAlbumApp.Core.ViewModels
{
    public class AlbumsViewModel : MvxViewModel
    {
        readonly IAlbumsApiService _albumsApiService;

        private List<Album> _albums;
        private bool _isBusy;

        public MvxCommand<Album> ShowAlbumDetailsCommand { get; private set; }

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

            ShowAlbumDetailsCommand = new MvxCommand<Album>(ShowAlbumDetails);
        }

        private void ShowAlbumDetails(Album album)
        {
            NavigationService.Navigate<AlbumDetailsViewModel, int>(album.Id);
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
