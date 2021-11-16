using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class ExchangeCurrency
    {
        public int id { set; get; }
        public int CurrencyID { set; get; }
        public Currency Currency { set; get; }
        public DateTime Date { set; get; }
        public float Sale { set; get; }
        public float Buy { set; get; }
    }
}
