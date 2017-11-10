using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext ctx = new MyDbContext();
            //ModifyMiddleName(ctx);
            //GroupingCompanyByInitial(ctx);
            //FollowRelationshipsToCountOrders(ctx);
            //AddCustomerIncomplete(ctx);

        }

        private static void AddCustomerIncomplete(MyDbContext ctx)
        {
            SalesLT_Customer newCustomer = new SalesLT_Customer()
            {
                CompanyName = "AAA",
                EmailAddress = "email@email.com",
                FirstName = "Bob",
                LastName = "Smith",
                Title = "Boss",
                Phone = "5551212"
            };
            ctx.SalesLT_Customers.Add(newCustomer);
            ctx.SaveChanges();
        }

        private static void FollowRelationshipsToCountOrders(MyDbContext ctx)
        {
            var q = from c in ctx.SalesLT_Customers
                    where c.CompanyName.StartsWith("A")
                    select new { customer = c, orders = c.SalesLT_SalesOrderHeaders };
            foreach (var item in q)
            {
                Console.WriteLine($"{item.customer.CompanyName} - {item.orders.Count}");
            }
        }

        private static void GroupingCompanyByInitial(MyDbContext ctx)
        {
            var q = from c in ctx.SalesLT_Customers
                    group c by c.CompanyName.Substring(0, 1) into CompanyInitial
                    orderby CompanyInitial.Key
                    select new { Initial = CompanyInitial.Key, CompanyCount = CompanyInitial.Count() };
            foreach (var item in q)
            {
                Console.WriteLine($"{item.Initial}: {item.CompanyCount}");
            }
        }

        private static void ModifyMiddleName(MyDbContext ctx)
        {
            var q = from c in ctx.SalesLT_Customers
                    where c.CompanyName.StartsWith("A")
                    select c;
            foreach (var item in q)
            {
                item.MiddleName = "x";
                Console.WriteLine($"{item.CompanyName} - {item.EmailAddress} - {item.LastName} -{item.MiddleName}");
            }
            ctx.SaveChanges();
        }
    }
}
