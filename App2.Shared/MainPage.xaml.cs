using App2.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App2
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }

        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.Init();
            
        }
    }
}
