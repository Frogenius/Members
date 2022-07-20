using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Members.Models;
using Members.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace Members.ViewModels
{
    public class MemberViewModel : BaseMemberViewModel
    {
        public ObservableCollection<Member> Members { get; }
        public Command LoadMembersCommand { get; }
        public Command AddMemberCommand { get; }
        public Command EditMemberCommand { get; }
        public Command DeleteMemberCommand { get; }

        public MemberViewModel(INavigation navigation)
        {
            Members = new ObservableCollection<Member>();
            LoadMembersCommand = new Command(async () => await ExecuteLoadMemberCommand());
            AddMemberCommand = new Command(OnAddMember);
            EditMemberCommand = new Command<Member>(OnEditMember);
            DeleteMemberCommand = new Command<Member>(OnDeleteMember);
            Navigation = navigation;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadMemberCommand()
        {
            IsBusy = true;

            try
            {
                Members.Clear();
                var membersList = await App.DataDB.GetMembers();

                foreach (var member in membersList)
                {
                    Members.Add(member);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during loading data " + ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddMember(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewMemberPage));
        }

        private async void OnEditMember(Member member)
        {
            await Navigation.PushAsync(new NewMemberPage(member));
        }

        private async void OnDeleteMember(Member member)
        {
            if (member == null)
            {
                return;
            }

            var wantsToDelete = await App.Current.MainPage.DisplayAlert("Usuń dane o członkie", "Czy na pewno chcesz usunąć dane?", "Tak", "Nie");
            if (wantsToDelete)
            {
                await App.DataDB.DeleteMember(member.MemberId);
                await App.Current.MainPage.DisplayAlert("Usunięto dane", "Pomyślnie usunięto dane o członkie", "OK");

               
               // vibrateDevice();

                await ExecuteLoadMemberCommand();
            }
        }

        private void vibrateDevice()
        {
            var duration = TimeSpan.FromSeconds(4);
            Vibration.Vibrate(duration);
        }
    }
}
