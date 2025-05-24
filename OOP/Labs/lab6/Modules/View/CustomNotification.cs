using System.Windows;
using System.Windows.Controls;

namespace KNP_Library.Modules.View
{
    public enum NotificationType { Success, Error, Warning }

    public class CustomNotification : Control
    {
        static CustomNotification()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomNotification),
                new FrameworkPropertyMetadata(typeof(CustomNotification)));
        }

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(CustomNotification), new PropertyMetadata(""));

        public NotificationType Type
        {
            get => (NotificationType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(NotificationType), typeof(CustomNotification), new PropertyMetadata(NotificationType.Success));
    }
}
