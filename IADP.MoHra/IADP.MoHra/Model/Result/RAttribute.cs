using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Result
{
    class RAttribute
    {
        public string Name { set; get; }
        public string Short { get; set; }
        public bool IsDirect { set; get; }
        public decimal JunMidValue { set; get; }
        public decimal MidSenValue { set; get; }

        public char GetClaster(decimal value)
        {
            char result = '\0';
            if (IsDirect)
            {
                if (value < JunMidValue)
                    result = 'J';
                else if (value < MidSenValue)
                    result = 'M';
                else
                    result = 'S';
            }
            else
            {
                if (value > JunMidValue)
                    result = 'J';
                else if (value > MidSenValue)
                    result = 'M';
                else
                    result = 'S';
            }
            return result;
        }
        public override string ToString()
        {
            return $"RAttribute: {Short}";
        }
    }
}
