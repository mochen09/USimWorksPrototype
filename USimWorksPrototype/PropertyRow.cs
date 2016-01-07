using System.Windows;
using System.Windows.Controls;

namespace USimWorksPrototype
{
    public class PropertyRow : Control
    {
        static PropertyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyRow), new FrameworkPropertyMetadata(typeof(PropertyRow)));
        }

        public static readonly DependencyProperty PropertyNameProperty = DependencyProperty.Register(
            "PropertyName", typeof (string), typeof (PropertyRow), new FrameworkPropertyMetadata("属性名称"));

        public string PropertyName
        {
            get { return (string) GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }
    }
}
