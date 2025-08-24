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
    public class RoomNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var details = value as IEnumerable;
            if (details == null) return string.Empty;

            return string.Join("\n", details
                .OfType<BookingDetail>()
                .Where(d => d.Room != null)
                .Select(d => d.Room.RoomNumber));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
