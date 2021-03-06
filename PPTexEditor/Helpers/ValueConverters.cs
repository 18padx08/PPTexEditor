﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace PPTexEditor.Helpers
{
    public class RowCellToStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var theRowCell = (int)value;
            switch(theRowCell)
            {
                case 0:
                    return Visibility.Collapsed;
                default:
                    return theRowCell % 8 == 0 || theRowCell / 8 == 0?Visibility.Visible:Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
