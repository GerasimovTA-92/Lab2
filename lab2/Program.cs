using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace lab2
{
    class Program
    {

        static object locker = new object();
        static int x = 0;

        static void Main(string[] args)
        {
            int a = 0;
            Stopwatch task_time = Stopwatch.StartNew();
            TestTask();
            var time1 = task_time.ElapsedMilliseconds;
            Stopwatch thread_time = Stopwatch.StartNew();
            TestThread();
            var time2 = thread_time.ElapsedMilliseconds;

            Thread add_users = new Thread(AddUser);
            add_users.Start();
            Thread.Sleep(500);

            Thread add_employees = new Thread(AddEmployee);
            add_employees.Start();
            Thread.Sleep(500);
            var ADDThreadAreDone = false;
            while (!ADDThreadAreDone)
            {
                ADDThreadAreDone = add_users.ThreadState == System.Threading.ThreadState.Stopped && add_employees.ThreadState == System.Threading.ThreadState.Stopped;
            }
            if(ADDThreadAreDone)
            {
                Thread read_users=new Thread(ReadUsers);
                read_users.Start();
                Thread.Sleep(5000);


                Thread read_employees = new Thread(ReadEmployees);
                read_employees.Start();
                Thread.Sleep(5000);
            }
            Console.WriteLine($"Время выполнения TestTask {time1} \nВремя выполнения TestThread {time2}");
        }
      


       
        public static void TestThread()
        {
            
            Thread test = new Thread(Generate);
            Thread.Sleep(100);
        }
        public static async void TestTask()
        {
            
            await Task.Run(() => Generate());
            Thread.Sleep(100);
        }
        public static void Generate()
        {
            lock(locker)
            {
                x = 1;
                Thread.Sleep(100);
                for (int i = 0; i < 1000; i++)
                {
                    x++;
                    
                }
            }
        }
        public static async void ReadUsers()
        {
            using (BankContext db = new BankContext())
            {
                Thread.Sleep(100);
                Console.WriteLine("Users: ");
                var users = await db.Users.ToListAsync();
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{users[i].Name} ");
                    Thread.Sleep(100);
                }
            }

        }
        public static async void ReadEmployees()
        {
            using (BankContext db = new BankContext())
            {
                Thread.Sleep(100);
                Console.WriteLine("Employees: ");
                var employees = await db.Employees.ToListAsync();
                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine($"{employees[i].Name} ");
                    Thread.Sleep(100);
                }
            }
        }
        public static void AddEmployee()
        {
            lock (locker)
            {
                x = 1;
                Console.WriteLine("thread 2:");
                Thread.Sleep(100);
                using (BankContext db = new BankContext())
                {
                    for (int i = 0; i < 25; i++)
                    {
                        db.Employees.Add(new EmployeeData { Name = $"Jeka_{i + 1}" });
                        db.SaveChanges();
                        Thread.Sleep(100);
                        x++;
                    }
                }
            }
        }

        public static void AddUser()
        {
            lock (locker)
            {
                Console.WriteLine("thread 1:");
                Thread.Sleep(100);
                using (BankContext db = new BankContext())
                {
                    for (int i = 0; i < 25; i++)
                    {

                        db.Users.Add(new UserData { Name = $"Alex_{i + 1}", EmployeeID = 1, Employee = db.Employees.ToList().FirstOrDefault() });
                        db.SaveChanges();
                        Thread.Sleep(100);
                    }
                }
            }
        }



        //using (BankContext db = new BankContext())
        //{

        //    var users = db.Users.Where(p => p.EmployeeID == 1003);
        //    foreach (UserData user in users)
        //        Console.WriteLine($"{user.Name} {user.Surname}");
        //}
        //using (BankContext db = new BankContext())
        //{
        //    var users = db.Users.OrderBy(p => p.Surname);
        //    Console.WriteLine($"=====================================================================================");
        //    foreach (UserData user in users)
        //        Console.WriteLine($"{user.Surname}");
        //}
        //using (BankContext db = new BankContext())
        //{
        //    var users1 = from user in db.Users
        //                 join card in db.Cards on user.id equals card.User_ID
        //                 join bill in db.Bills on card.Bill_Number equals bill.Number
        //                 select new
        //                 {
        //                     Name = user.Name,
        //                     Surname = user.Surname,
        //                     NumberOfBill = bill.Number
        //                 };
        //    Console.WriteLine($"=====================================================================================");
        //    foreach (var user in users1)
        //        Console.WriteLine($"{user.Name} {user.Surname} - {user.NumberOfBill}");
        //    //group by
        //    var group = from c in db.Cards
        //                group c by c.User.Name into g
        //                select new
        //                {
        //                    g.Key,
        //                    count = g.Count()
        //                };
        //    Console.WriteLine($"=====================================================================================");
        //    foreach (var gr in group)
        //        Console.WriteLine($"{gr.Key} - {gr.count}");
        //    //union
        //    var union = db.Users.Select(p => new { Name = p.Name })
        //        .Union(db.Employees.Select(p => new { Name = p.Name }));
        //    Console.WriteLine($"=====================================================================================");
        //    foreach (var u in union)
        //        Console.WriteLine($"{u.Name}");
        //    //intersect
        //    var intersect = db.Users.Select(p => new { Name = p.Name })
        //        .Intersect(db.Employees.Select(p => new { Name = p.Name }));
        //    Console.WriteLine($"=====================================================================================");
        //    foreach (var u in intersect)
        //        Console.WriteLine($"{u.Name}");
        //    //except
        //    var except = db.Users.Select(p => new { Name = p.Name })
        //        .Except(db.Employees.Select(p => new { Name = p.Name }));
        //    Console.WriteLine($"=====================================================================================");
        //    foreach (var u in except)
        //        Console.WriteLine($"{u.Name}");
        //    //

        //}
        //using(BankContext db =new BankContext())
        //{
        //    Console.WriteLine($"=====================================================================================");
        //    Microsoft.Data.SqlClient.SqlParameter param1 = new Microsoft.Data.SqlClient.SqlParameter("@money", 10);
        //    Microsoft.Data.SqlClient.SqlParameter param2 = new Microsoft.Data.SqlClient.SqlParameter("@sender_id", 4);
        //    Microsoft.Data.SqlClient.SqlParameter param3 = new Microsoft.Data.SqlClient.SqlParameter("@recipient_id", 5);
        //    Microsoft.Data.SqlClient.SqlParameter param4 = new Microsoft.Data.SqlClient.SqlParameter("@exchange_id", 1);
        //    var bills = db.Bills.FromSqlRaw("transaction_operation @money, @sender_id, @recipient_id, @exchange_id", param1, param2,param3,param4).ToList();
        //    foreach(var b in bills)
        //    {
        //        Console.WriteLine($"{b.id} {b.Number} {b.Balance}");
        //    }
        //}
        ////найти клиента который совершил наибольшое колич операций 
        //using(BankContext db=new BankContext())
        //{

        //    var groups = from op in db.Operations
        //                 where op.Date > new DateTime ( 2021, 11,6 ) 
        //                 group op by op.BillID into gr

        //                 select new
        //                 {
        //                     gr.Key,
        //                     count = gr.Count()
        //                 };
        //    Console.WriteLine("#####");
        //    foreach (var g in groups)
        //    {
        //        Console.WriteLine($"{g.Key} - {g.count}");
        //    }
        //    var b = groups.Where(p => p.count == groups.Max(g => g.count));
        //    Console.WriteLine("#####");
        //    foreach (var g in b)
        //    {
        //        Console.WriteLine($"{g.Key} - {g.count}");
        //    }


        //}
        ////add
        //using (BankContext db = new BankContext())
        //{

        //    EmployeeData employee1 = new EmployeeData { Name = "Pavlo", Surname = "Ptichka", Login = "4erepawka", Password = "123131" };
        //    EmployeeData employee2 = new EmployeeData { Name = "Nikita", Surname = "Popovich", Login = "the_best", Password = "188098" };
        //    UserData user1 = new UserData { Name = "Alex", Surname = "Gerasimov", Login = "alex_ger", Password = "12313", EmployeeID = 1, Employee = employee1 };
        //    UserData user2 = new UserData { Name = "Jeka", Surname = "Gerasimov", Login = "jeka", Password = "54321", EmployeeID = 2, Employee = employee2 };
        //    Currency usd = new Currency { Country = "USA", Name = "USD" };
        //    Currency eur = new Currency { Name = "EUR", Country = "England" };
        //    Currency uah = new Currency { Country = "Ukraine", Name = "UAH" };
        //    Bill bill1 = new Bill { Balance = 0, Currency = uah, Currency_ID = 3, Number = "028929" };
        //    Bill bill2 = new Bill { Balance = 5000, Currency = uah, Currency_ID = 3, Number = "7091285" };
        //    Card card1_for_user1 = new Card { User = user1, User_ID = 1, Bill = bill1, Bill_Number = "028929", CVC_code = "540", Number = "7808908896321450", Validity = new DateTime(2023, 10, 11) };
        //    Card card1_for_user2 = new Card { User = user2, User_ID = 2, Bill = bill2, Bill_Number = "7091285", CVC_code = "807", Number = "8484848484800562", Validity = new DateTime(2022, 10, 11) };
        //    db.Users.Add(user1);
        //    db.Users.Add(user2);
        //    db.Employees.Add(employee1);
        //    db.Employees.Add(employee2);
        //    db.Cards.Add(card1_for_user2);
        //    db.Cards.Add(card1_for_user1);
        //    db.Bills.Add(bill1);
        //    db.Bills.Add(bill2);
        //    db.Currencies.Add(eur);
        //    db.Currencies.Add(usd);
        //    db.Currencies.Add(uah);
        //    db.SaveChanges();
        //}

        ////get
        //using(BankContext db = new BankContext())
        //{
        //    var users = db.Users.ToList();
        //    Console.WriteLine("after add");
        //    foreach (UserData user in users)
        //    {
        //        Console.WriteLine($"{user.id}.{user.Name}   {user.Surname} - {user.EmployeeID}");
        //    }
        //    var empl = db.Employees.ToList();
        //    foreach (EmployeeData e in empl)
        //        Console.WriteLine($"{e.id}.{e.Name}   {e.Surname} ");
        //}

        ////Edit
        //using (BankContext db = new BankContext())
        //{
        //    var users = db.Users.ToList();
        //    foreach (UserData u in users)
        //    {
        //        if (u.id == 1)
        //        {
        //            u.Name = "Tom";
        //            db.SaveChanges();
        //        }
        //    }
        //}
        ////get
        //using (BankContext db = new BankContext())
        //{
        //    var users = db.Users.ToList();
        //    Console.WriteLine("after edit");
        //    foreach (UserData user in users)
        //    {
        //        Console.WriteLine($"{user.id}.{user.Name}   {user.Surname} - {user.EmployeeID}");
        //    }
        //    var empl = db.Employees.ToList();
        //    foreach (EmployeeData e in empl)
        //        Console.WriteLine($"{e.id}.{e.Name}   {e.Surname} ");
        //}
        //using (BankContext db=new BankContext())
        //{
        //    UserData user = db.Users.FirstOrDefault();
        //    if(user!=null)
        //    {
        //        db.Users.Remove(user);
        //        db.SaveChanges();
        //    }

        //}
        //using (BankContext db = new BankContext())
        //{
        //    var users = db.Users.ToList();
        //    Console.WriteLine("after remove");
        //    foreach (UserData user in users)
        //    {
        //        Console.WriteLine($"{user.id}.{user.Name}   {user.Surname} - {user.EmployeeID}");
        //    }
        //    var empl = db.Employees.ToList();
        //    foreach (EmployeeData e in empl)
        //        Console.WriteLine($"{e.id}.{e.Name}   {e.Surname} ");
        //}


    }
}

