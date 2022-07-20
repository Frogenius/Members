using Plugin.LocalNotification;

namespace Members.Notification
{
    public class Notification
    {
        public static async void createNotification(string title, string description, int notifId)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = description,
                Title = title,
                NotificationId = notifId,
            };
            await NotificationCenter.Current.Show(notification);
        }
    }
}