using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Bill
    {
        public int id { set; get; }
        public string Number { set; get; }
        public float Balance { set; get; }
        public int Currency_ID { set; get; }
        public Currency Currency { set; get; }
    }
}
