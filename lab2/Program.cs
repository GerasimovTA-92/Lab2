using System;
using System.Linq;

namespace lab2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //add
            using (BankContext db=new BankContext())
            {
                UserData user1 = new UserData { Name = "Alex", Surname = "Gerasimov", Login = "alex_ger", Password = "12313" };
                UserData user2 = new UserData { Name = "Jeka", Surname = "Gerasimov", Login = "jeka", Password = "54321" };
                EmployeeData employee1 = new EmployeeData { Name = "Pavlo", Surname = "Ptichka",  Login = "4erepawka", Password = "123131", UserID = 1, User = user1 };
                EmployeeData employee2 = new EmployeeData { Name = "Nikita", Surname = "Popovich",  Login = "the_best", Password = "188098", UserID = 2, User = user2 };
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Employees.Add(employee1);
                db.Employees.Add(employee2);
                db.SaveChanges();
            }

            //get
            using(BankContext db = new BankContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("after add");
                foreach(UserData user in users)
                {
                    Console.WriteLine($"{user.id}.{user.Name}   {user.Surname}");
                }
                var empl = db.Employees.ToList();
                foreach(EmployeeData e in empl)
                    Console.WriteLine($"{e.id}.{e.Name}   {e.Surname} - {e.User.Surname}");
            }

            //Edit
            using (BankContext db = new BankContext())
            {
                var users = db.Users.ToList();
                foreach (UserData u in users)
                {
                    if (u.id == 1)
                    {
                        u.Name = "Tom";
                        db.SaveChanges();
                    }
                }
            }
            //get
            using (BankContext db = new BankContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("after edit");
                foreach (UserData user in users)
                {
                    Console.WriteLine($"{user.id}.{user.Name}   {user.Surname}");
                }
                var empl = db.Employees.ToList();
                foreach (EmployeeData e in empl)
                    Console.WriteLine($"{e.id}.{e.Name}   {e.Surname} - {e.User.Name}");
            }
            using (BankContext db=new BankContext())
            {
                UserData user = db.Users.FirstOrDefault();
                if(user!=null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

            }
            using (BankContext db = new BankContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("after remove");
                foreach (UserData user in users)
                {
                    Console.WriteLine($"{user.id}.{user.Name}   {user.Surname}");
                }
                var empl = db.Employees.ToList();
                foreach (EmployeeData e in empl)
                    Console.WriteLine($"{e.id}.{e.Name}   {e.Surname} - {e.User.Name}");
            }
        }
    }
}

