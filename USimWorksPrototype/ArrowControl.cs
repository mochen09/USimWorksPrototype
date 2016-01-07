using System.Windows;
using System.Windows.Controls;

namespace USimWorksPrototype
{
    public class ArrowControl : Control
    {
        static ArrowControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ArrowControl),
                new FrameworkPropertyMetadata(typeof (ArrowControl)));
        }

        public static readonly DependencyProperty OriProperty = DependencyProperty.Register(
            "Ori", typeof (Orientation), typeof (ArrowControl), new FrameworkPropertyMetadata(Orientation.Up));

        public Orientation Ori
        {
            get { return (Orientation) GetValue(OriProperty); }
            set { SetValue(OriProperty, value); }
        }
    }

    public enum Orientation
    {
        Up,
        Down,
        Left,
        Right
    }
}
