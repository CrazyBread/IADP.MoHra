﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Result
{
    class RObject
    {
        public string Name { set; get; }
        public int RoomNumber { set; get; }
        //public int Experience { set; get; } -- для 3й лабы, возможно.


        public override string ToString()
        {
            return $"RObject: {Name}";
        }
    }
}
