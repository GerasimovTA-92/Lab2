using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Operation
    {
        public int id { set; get; }
        public string Number { set; get; }
        public double Sum { set; get; }
        public string Type { set; get; }
        public DateTime Date { set; get; }
        public int BillID { set; get; }
        public Bill Bill { set; get; } 
        public int ExchangeCurrencyID { set; get; }
        public ExchangeCurrency currency { set; get; }
    }
}
