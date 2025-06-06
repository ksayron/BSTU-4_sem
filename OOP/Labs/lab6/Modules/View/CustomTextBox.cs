using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace KNP_Library.Modules.View
{
    public class CustomTextBox : TextBox
    {
        public static readonly DependencyProperty MaxAllowedLengthProperty = DependencyProperty.Register(
            "MaxAllowedLength",
            typeof(int),
            typeof(CustomTextBox),
            new FrameworkPropertyMetadata(20, null, CoerceLength),
            ValidateMaxLength);

        public int MaxAllowedLength
        {
            get => (int)GetValue(MaxAllowedLengthProperty);
            set => SetValue(MaxAllowedLengthProperty, value);
        }

        private static bool ValidateMaxLength(object value)
        {
            return (int)value > 0;
        }

        private static object CoerceLength(DependencyObject d, object baseValue)
        {
            var textBox = (CustomTextBox)d;
            int max = (int)baseValue;
            if (textBox.Text.Length > max)
            {
                textBox.Text = textBox.Text.Substring(0, max);
            }
            return baseValue;
        }
    }
    public class CustomEventSource : Control
    {
        public static readonly RoutedEvent BubblingEvent = EventManager.RegisterRoutedEvent(
            "Bubbling", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomEventSource));

        public static readonly RoutedEvent TunnelingEvent = EventManager.RegisterRoutedEvent(
            "Tunneling", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(CustomEventSource));

        public static readonly RoutedEvent DirectEvent = EventManager.RegisterRoutedEvent(
            "Direct", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(CustomEventSource));

        public event RoutedEventHandler Bubbling
        {
            add => AddHandler(BubblingEvent, value);
            remove => RemoveHandler(BubblingEvent, value);
        }

        public event RoutedEventHandler Tunneling
        {
            add => AddHandler(TunnelingEvent, value);
            remove => RemoveHandler(TunnelingEvent, value);
        }

        public event RoutedEventHandler Direct
        {
            add => AddHandler(DirectEvent, value);
            remove => RemoveHandler(DirectEvent, value);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            RaiseEvent(new RoutedEventArgs(BubblingEvent));
            RaiseEvent(new RoutedEventArgs(TunnelingEvent));
            RaiseEvent(new RoutedEventArgs(DirectEvent));
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

     
            drawingContext.DrawRectangle(Brushes.LightBlue, new Pen(Brushes.Black, 1), new Rect(0, 0, ActualWidth, ActualHeight));

            drawingContext.DrawText(
                new FormattedText("Click me!", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    new Typeface("Arial"), 16, Brushes.Black),
                new Point(ActualWidth / 4, ActualHeight / 4));
        }
    }
    public class StarFillConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3 ||
                !(values[0] is int index) ||
                !(values[1] is int rating) ||
                !(values[2] is int previewRating))
            {
                return Brushes.Transparent;
            }

            var currentRating = previewRating > 0 ? previewRating : rating;
            return index < currentRating ? Brushes.Gold : Brushes.Transparent;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



}
