using Xamarin.Forms;

namespace Members.Triggers
{
    public class EntryAndButtonTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
          //  var priceEntry = sender as Entry;
           // var priceFlag = float.TryParse(priceEntry.Text, out float price);
          //  priceEntry.TextColor = price == 0.0 ? Color.Red : Color.Gray;
        }

        public class PhoneLengthTrigger : TriggerAction<Entry>
        {
            protected override void Invoke(Entry sender)
            {
                var phoneEntry = sender as Entry;
                var phoneLength = phoneEntry.Text.Length;
                phoneEntry.TextColor = phoneLength < 9 ? Color.Red : Color.Gray;
            }
        }

        public class ButtonStartTrigger : TriggerAction<Button>
        {
            protected override void Invoke(Button btn)
            {
                btn.BackgroundColor = Color.DarkOrange;
                btn.Text = "Startujemy!";
            }
        }

        public class ButtonFormTrigger : TriggerAction<Button>
        {
            protected override void Invoke(Button btn)
            {
                btn.BackgroundColor = Color.DarkOrange;
            }
        }
    }
}