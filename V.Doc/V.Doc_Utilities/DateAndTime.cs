using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Utilities
{
    public class DateAndTime
    {
        public int GetAge(DateTime Birthdate)
        {
            return DateTime.Now.Year - Birthdate.Year;
        }
    }
}
