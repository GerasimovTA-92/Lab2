using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class EmployeeData
    {
        public int id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public int UserID { set; get; }
        public UserData User { set; get; }
    }
}
