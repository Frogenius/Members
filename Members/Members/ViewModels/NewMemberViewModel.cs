using System;
using Members.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Members.Notification;

namespace Members.ViewModels
{
    public class NewMemberViewModel : BaseMemberViewModel
    {
        public Command SaveMemberCommand { get; }
        public Command CancelCommand { get; }

         public NewMemberViewModel()
         {
             SaveMemberCommand = new Command(OnSaveMember);
             CancelCommand = new Command(OnCancel);
             this.PropertyChanged += (_, __) => SaveMemberCommand.ChangeCanExecute();
             Member = new Member();
         } 

       private async void OnSaveMember()
         {
             var member = Member;
             if (CheckIfFieldsAreNotEmpty(member) && ChechIfFieldsHaveProperLength(member))
             {
                 await App.DataDB.AddMember(member);
                 await App.Current.MainPage.DisplayAlert("Zapisano dane", "Pomyślnie zapisano dane " + member.Name, "OK");

             
                // vibrateDevice();

                 await Shell.Current.GoToAsync("//MembersListPage");
             }
         }
        
        private bool CheckIfFieldsAreNotEmpty(Member member)
        {
            if (FieldsAreNotEmpty(member))
            {
                return true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Brak danych o czlonkie", "Uzupełnij wszystkie pola danymi", "OK");
                return false;
            }
        }

        private bool FieldsAreNotEmpty(Member member)
        {
            return !string.IsNullOrWhiteSpace(member.Name)
                && !string.IsNullOrWhiteSpace(member.Experience)                            
                && !string.IsNullOrWhiteSpace(member.Age)
                && !string.IsNullOrWhiteSpace(member.Email)
                && !string.IsNullOrWhiteSpace(member.PhoneNumber)
                && !string.IsNullOrWhiteSpace(member.City);
        }

        private bool ChechIfFieldsHaveProperLength(Member member)
        {
            if (member.Name.Length < 1 || member.Name.Length > 10)
            {
                App.Current.MainPage.DisplayAlert("Za krótka nazwa", "Musi posiadać od 1 do 20 znaków", "OK");
                return false;
            }
            if (member.Experience.Length < 1 || member.Experience.Length > 50)
            {
                App.Current.MainPage.DisplayAlert("Za krótki opis", "Opis produktu musi posiadać od 1 do 50 znaków", "OK");
                return false;
            }
            if (member.PhoneNumber.Length < 9 || member.PhoneNumber.Length > 15)
            {
                App.Current.MainPage.DisplayAlert("Za krótki numer", "Numer telefonu musi posiadać od 9 do 15 cyfr", "OK");
                return false;
            }
            return true;
        }

       

        private void vibrateDevice()
        {
            var duration = TimeSpan.FromSeconds(3);
            Vibration.Vibrate(duration);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//MembersListPage");
        }

 
        }

       

       

   
    
}
