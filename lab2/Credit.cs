using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Credit
    {
        public int id { set; get; }
        public DateTime Term { set; get; }
        public int Percent { set; get; }
        public string Type { set; get; }
        public string Guarantor { set; get; }
        public string Pledge { set; get; }
        public float Amount { set; get; }
    }
}
