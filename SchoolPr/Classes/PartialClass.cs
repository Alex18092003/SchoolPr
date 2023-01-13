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
                    Cc = (int)Cost - (int)Cost/1000  * (int)Discount;
                    return Cost + " "+ Cc + " рублей за 30 минут";
                }
                else
                {
                    return Cost + " рублей за 30 минут";
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
