using MusicAlbumApp.Core.Models;
using MusicAlbumApp.Core.Services;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicAlbumApp.Core.ViewModels
{
    public class AlbumDetailsViewModel : MvxViewModel<int>
    {
        readonly IAlbumsApiService _albumsApiService;

        private List<AlbumDetails> _albumDetails;

        public List<AlbumDetails> AlbumDetails
        {
            get => _albumDetails;
            set => SetProperty(ref _albumDetails, value);
        }

        public AlbumDetailsViewModel(IAlbumsApiService albumsApiService)
        {
            _albumsApiService = albumsApiService;
        }

        public override async void Prepare(int parameter)
        {
            AlbumDetails = await _albumsApiService.GetAlbumDetailsAsync(parameter);
        }
    }
}
