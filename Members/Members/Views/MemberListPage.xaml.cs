using System.Linq;
using Members.Models;
using Members.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Members.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberListPage : ContentPage
    {
        private MemberViewModel memberViewModel;
        public MemberListPage()
        {
            InitializeComponent();
            BindingContext = memberViewModel = new MemberViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            memberViewModel.OnAppearing();
        }
        private async void Members_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMember = e.CurrentSelection.FirstOrDefault() as Member;
            await Navigation.PushAsync(new MemberDetailPage()
            {
                BindingContext = selectedMember
            });
        }
    }
}