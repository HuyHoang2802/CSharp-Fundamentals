using BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp.Converters
{
    public class StartDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bookingDetails = value as IEnumerable;
            if (bookingDetails == null) return string.Empty;

            return string.Join("\n", bookingDetails
                .OfType<BookingDetail>()
                .Select(d => d.StartDate.ToString("dd/MM/yyyy")));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
