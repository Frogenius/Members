using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Members.Models;
using Members.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Members.Triggers;

namespace Members.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMemberPage : ContentPage
    {
        public Member Member { get; set; }
        public string PageTitle { get; set; }
        public NewMemberPage()
        {
            InitializeComponent();
            BindingContext = new NewMemberViewModel();
        }
        public NewMemberPage(Member member)
        {
            InitializeComponent();
            BindingContext = new NewMemberViewModel();
            if (member != null)
            {
                ((NewMemberViewModel)BindingContext).Member = member;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}