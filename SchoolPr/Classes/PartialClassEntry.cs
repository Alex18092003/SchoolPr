using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchoolPr
{
   public partial class ClientService
    {
        

        public SolidColorBrush Colorr
        {
            get
            {
                TimeSpan timeSpan = StartTime - DateTime.Now;
                TimeSpan oneHour = TimeSpan.FromHours(1);
                Brush brush = new SolidColorBrush(Color.FromRgb(4, 160, 255));
                if (timeSpan < oneHour)
                {
                    return Brushes.Red;
                }
    
                return (SolidColorBrush)brush;
            }
        }

        int minute;
        int hour;
        public string Time
        {
            get
            {
                TimeSpan timeSpan = StartTime - DateTime.Now;
                if(timeSpan.Days > 0)
                {
                    hour += 24 * Convert.ToInt32(timeSpan.Days);
                }
                hour += Convert.ToInt32(timeSpan.ToString("hh"));
                minute = Convert.ToInt32(timeSpan.ToString("mm"));
                return " " + hour + " ч. " + minute + " мин." ;
            }
        }
    }

}
