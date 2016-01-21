using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidades
{
    public static class UtilsTipos
    {
        public static int? toIntN(string s)
        {
            int? ret;
            try
            {
                ret = (int?)Convert.ToInt32(s);
                return ret;
            }
            catch (FormatException fe)
            {

            }
            return null;
        }
        public static int toInt(string s)
        {
            int ret;
            try
            {
                ret = Convert.ToInt32(s);
                return ret;
            }
            catch (FormatException fe)
            {

            }
            return 0;
        }  
    }
}
