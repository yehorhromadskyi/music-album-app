using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MusicAlbumApp.Core.Services;
using System.Threading.Tasks;
using MusicAlbumApp.Core.Models;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

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
