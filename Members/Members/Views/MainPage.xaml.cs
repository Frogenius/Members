using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Members.Views
{
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void StartApp_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"//MembersListPage");
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            imageSender.Opacity = 0;
            await imageSender.FadeTo(1, 4000);
        }
    }
}