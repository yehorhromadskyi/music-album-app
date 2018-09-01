using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MusicAlbumApp.Core
{
    public class CustomAppStart<TViewModel> : MvxAppStart<TViewModel>
        where TViewModel : IMvxViewModel
    {
        public CustomAppStart(
            IMvxApplication application,
            IMvxNavigationService navigationService) : base(application, navigationService)
        {

        }

        protected override void NavigateToFirstViewModel(object hint = null)
        {
            NavigationService.Navigate<TViewModel>();
        }
    }
}
