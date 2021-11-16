using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Deposit
    {
        public int id { set; get; }
        public DateTime Term { set; get; }
        public int Percent { set; get; }
        public string Type { set; get; }
        public float Current_Amount { set; get; }
        public float Initial_Amount { set; get; }
    }
}
