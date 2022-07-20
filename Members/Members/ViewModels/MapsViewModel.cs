using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace Members.ViewModels
{
    public class MapsViewModel : INotifyPropertyChanged
    {
        public ICommand ShowMapsCommand { get; set; }
        public ICommand ShowMyPositionCommand { get; set; }
        private Map googleMaps;

        public event PropertyChangedEventHandler PropertyChanged;

        public Map GoogleMaps
        {
            get { return googleMaps; }
            set { googleMaps = value; OnPropertyChanged("GoogleMaps");  }

        }

        public MapsViewModel()
        {
            ShowMapsCommand = new Command(ShowMaps);
            ShowMyPositionCommand = new Command(async () => await ShowMyPosition());
        }

        private void ShowMaps(object obj)
        {
            GoogleMaps = new Map();
        }
        private async Task ShowMyPosition()
        {
            var locator = CrossGeolocator.Current;
            var location = await locator.GetPositionAsync(TimeSpan.FromSeconds(3000));
            var position = new Position(location.Latitude, location.Longitude);
            var pin = new Pin()
            {
                Label = "Jesteś tutaj",
                Address = "Moja geolokacja",
                Type = PinType.Place,
                Position = position
            };
            googleMaps.Pins.Add(pin);
            googleMaps.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.3)));
        }
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
