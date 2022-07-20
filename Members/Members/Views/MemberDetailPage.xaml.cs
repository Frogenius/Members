using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Members.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Members.Views
{
    [QueryProperty(nameof(MemberId), nameof(MemberId))]
    public partial class MemberDetailPage : ContentPage
    {
        private int memberId;
        public MemberDetailPage()
        {
            InitializeComponent();
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            var imageScale = imageSender.Scale;
            await imageSender.ScaleTo(imageScale * 1.2, 500);
            await imageSender.ScaleTo(imageScale, 500);
        }

        public int MemberId
        {
            get
            {
                return MemberId;
            }
            set
            {
                memberId = value;
            }
        }
    }
}