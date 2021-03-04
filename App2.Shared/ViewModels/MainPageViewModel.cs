using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace App2.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;
        private BitmapImage _cover;

        public MainPageViewModel()
        {
            _httpClient = App.Client;
        }

        public BitmapImage Cover
        {
            get => _cover;
            set => SetProperty(ref _cover, value);
        }

        public async Task Init()
        {
            var response = await _httpClient.GetAsync($"https://cdn.pixabay.com/photo/2018/09/04/10/27/learn-3653430_1280.jpg");
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                using (var memStream = new MemoryStream())
                {
                    var image = new BitmapImage();
                    await stream.CopyToAsync(memStream);
                    memStream.Position = 0;
                    await image.SetSourceAsync(memStream.AsRandomAccessStream());
                    Cover = image;
                }
            }
        }
    }
}
