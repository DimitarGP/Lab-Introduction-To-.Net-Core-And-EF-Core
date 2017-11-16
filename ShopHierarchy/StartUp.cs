using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ShopHierarchy
{
    public class StartUp
    {
        static void Main()
        {
            using (var db = new MyDbContext())
            {
                Preparedatabase(db);
                SaveSalesman(db);
                ProcessComand(db);
                //PrintSalesmanWithCustomer(db);
                PrintCustomerWithOrderAndReviewCount(db);
            }
        }

        private static void Preparedatabase(MyDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static void SaveSalesman(MyDbContext db)
        {
            var salesman = Console.ReadLine().Split(';');
            foreach (var sm in salesman)
            {
                db.Add(new Salesman {Name = sm});
            }

            db.SaveChanges();
        }

        private static void ProcessComand(MyDbContext db)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var parts =line.Split('-');
                var comand = parts[0];
                var args = parts[1];

                switch (comand)
                {
                    case "register":
                        RecisterCustomer(db, args);
                        break;
                    case "order":
                        SaveOrder(db, args);
                        break;
                    case "review":
                        SaveReview(db, args);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RecisterCustomer(MyDbContext db, string args)
        {
            var parts =  args.Split(';');
            var customerName = parts[0];
            var salesmanId = int.Parse(parts[1]);

            db.Add(new Customer
            {
                Name = customerName,
                SalesmanId = salesmanId
            });

            db.SaveChanges();
        }

        private static void PrintSalesmanWithCustomer(MyDbContext db)
        {
            //var salesmanData = db
            //    .Salesman
            //    .Include(s => s.Customers)
            //    .OrderByDescending(s => s.Customers.Count)
            //    .ThenBy(s => s.Name)
            //    .ToList();
            //foreach (var salesman in salesmanData)
            //{
            //    Console.WriteLine($"{salesman.Name} - {salesman.Customers.Count} counts");
            //}


            var salesmanData = db
                .Salesman
                .Select(s => new
                {
                    s.Name,
                    Customers = s.Customers.Count
                })
                .OrderByDescending(s => s.Customers)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var salesman in salesmanData)
            {
                Console.WriteLine($"{salesman.Name} – {salesman.Customers} customers ");
            }
        }

        private static void SaveOrder(MyDbContext db, string args)
        {
            var customerId = int.Parse(args);
            db.Add(new Order
            {
                CustomerId = customerId
            });

            db.SaveChanges();
        }

        private static void SaveReview(MyDbContext db, string args)
        {
            var customerId = int.Parse(args);
            db.Add(new Review
            {
                CustomerId = customerId
            });

            db.SaveChanges();
        }

        private static void PrintCustomerWithOrderAndReviewCount(MyDbContext db)
        {
            var customersData = db
                .Customers
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(c => c.Orders)
                .ThenBy(c => c.Reviews)
                .ToList();

            foreach (var customer in customersData)
            {
                Console.WriteLine(
                    $"{customer.Name}\n\rOrders: {customer.Orders}\n\rReviews: {customer.Reviews}");
            }
        }
    }
}
