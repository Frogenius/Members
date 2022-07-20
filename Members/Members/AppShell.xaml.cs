using System;
using Xamarin.Forms;
using Members.Views;

namespace Members
{
   
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewMemberPage), typeof(NewMemberPage));
        }

        private async void OnMenuLeaveItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        private async void TwoMenuLeaveItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AboutPage");
        }

        private async void MenuAddItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewMemberPage));
        }

    }
}