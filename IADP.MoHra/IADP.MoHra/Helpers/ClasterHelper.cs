using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Helpers
{
    static class ClasterHelper
    {
        public static string GetFullName(char claster)
        {
            switch (claster)
            {
                case 'J':
                    return "\"Младшие разработчики\"";
                case 'M':
                    return "\"Средние разработчики\"";
                case 'S':
                    return "\"Старшие разработчики\"";
            }
            return claster.ToString();
        }
    }
}
