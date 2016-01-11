using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using USimWorksPrototype.ViewModel;

namespace USimWorksPrototype
{
    public class SoftwareIconConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ModelType modelType = (ModelType) value;
            switch (modelType)
            {
                case ModelType.C:
                    return new BitmapImage(new Uri(@"Icon/C.png", UriKind.Relative));
                case ModelType.MatLab:
                    return new BitmapImage(new Uri(@"icon/Matlab.png", UriKind.Relative));
                case ModelType.Updm:
                    return new BitmapImage(new Uri(@"icon/UPDM.ico", UriKind.Relative));
                case ModelType.Rhapsody:
                    return new BitmapImage(new Uri(@"icon/Rhapsody.png", UriKind.Relative));
                case ModelType.SkyEye:
                    return new BitmapImage(new Uri(@"icon/SkyEye.png", UriKind.Relative));
                case ModelType.Other:
                    return new BitmapImage(new Uri(@"icon/software.png", UriKind.Relative));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
