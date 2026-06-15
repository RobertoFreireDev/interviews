using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.DataAccess.Utils
{
    public static class BoolUtil
    {
        public static string ConvertBoolToString(bool value) 
        {
            return value ? "'TRUE'" : "'FALSE'";
        }
    }
}
