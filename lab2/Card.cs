using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Card
    {
        public int id { set; get; }
        public string Number { set; get; }
        public DateTime Validity { set; get; }
        public string CVC_code { set; get; }
        public int User_ID { set; get; }
        public UserData User { set; get; }
        public string Bill_Number { set; get; }
        public Bill Bill { set; get; }
    }
}
