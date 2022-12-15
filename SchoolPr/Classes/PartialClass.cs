using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPr
{
    public partial class Service
    {
        int Cc =0;
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
                    return "* скидка " + Discount * 100 + "%";
                }
                else
                {
                    return null;
                }
               
            }
        }

    }
}
