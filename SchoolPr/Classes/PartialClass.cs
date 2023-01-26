using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchoolPr
{
    public partial class Service
    {
        double Cc =0;
        public string C
        {
            get
            {
                if (Discount != null)
                {
                    //Cc =  ((int)Cost/100)  * (100-(int)Discount*100);
                    double b = (Convert.ToDouble(Cost) / 100) * (100 - (Discount.Value * 100));
                    int time = DurationInSeconds / 60;
                    return b + " рублей за " +time+ " минут";
                }
                else
                {
                    int time = DurationInSeconds / 60;
                    return (int)Cost + " рублей за " + time + " минут";
                }

            }
        }

        public string P
        {
            get
            {
                if (Discount != null)
                {
                    return (int)Cost + " ";
                }
                else
                {
                    return "";
                }

            }
        }

        public string D
        {
            get
            {
                if(Discount != null)
                {
                    return "* скидка " + Discount.Value * 100 + "%";
                }
                else
                {
                    return "";
                }
               
            }
        }

        public SolidColorBrush ServiceColor 
        {
            get
            {
                if (Discount > 0)
                {
                    return Brushes.LightGreen;
                }
                else
                {

                    return Brushes.White;
                }

            }
        }

    }
}
