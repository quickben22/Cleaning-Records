using CleaningRecords.DAL;
using CleaningRecords.Global;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace CleaningRecords
{


    public class RepeatJobIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is int && (int)value != 0)
            {

                using (var db = new PodaciContext())
                {
                    var rj = db.RepeatJobs.FirstOrDefault(x => x.Id == (int)value);
                    if (rj?.RepeatFrequency != null)
                        return ZP.RepeatDict[rj.RepeatFrequency];
                }

            }

            return ZP.RepeatDict[0];
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



}
