using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Service
    {
        public int id { set; get; }
        public string Type { set; get; }
        public int Credit_ID { set; get; }
        public Credit Credit { set; get; }
        public int Deposit_ID { set; get; }
        public Deposit Deposit { set; get; }
    }
}
