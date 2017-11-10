using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection())
            { 
                conn.ConnectionString =
                    "Server=tcp:kmddemo.database.windows.net,1433;Initial Catalog=kmddb;Persist Security Info=False;User ID=chinzilla;Password=Pa$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                conn.Open();
                string query = "Select * from SalesLT.Product";
                SqlCommand cmd = new SqlCommand(query, conn);
                //SqlDataReader reader = cmd.ExecuteReader();
                Task<SqlDataReader> theTask = cmd.ExecuteReaderAsync();
                while (!theTask.IsCompleted)
                {
                    Console.Write(".");

                }
                SqlDataReader reader = theTask.Result;
                List<ProdPrice> prodList = new List<ProdPrice>();
                while (reader.Read())
                {
                    //Console.WriteLine($"{reader["Name"]} : {reader["ListPrice"]} ");
                    prodList.Add(new ProdPrice { Name = reader.GetString(1),
                        Price = reader.GetDecimal(5) });
                }
                var q =
                     from p in prodList
                     group p by p.Name[0] into InitGroup
                     orderby InitGroup.Key
                     select new
                     {
                         GroupKey = InitGroup.Key,
                         NumberOfProduct = InitGroup.Count(),
                         Products = InitGroup.OrderByDescending(p=>p.Price).Skip(3).Take(5),
                         GroupPriceTotal = InitGroup.Sum(p=>p.Price)
                     };
                
                foreach (var item in q)
                {
                    Console.WriteLine($"Group:{item.GroupKey} " +
                        $"- TotalPrice:{item.GroupPriceTotal} - " +
                        $"ProductCount :{item.NumberOfProduct} " );
                    foreach (var product in item.Products)
                    {
                        Console.WriteLine($"\t{product.Name}:{product.Price:C}");
                    }

                }

            }//conn.Dispose() is called because end of using{}
        }
        class ProdPrice
        {
            public string Name;
            public decimal Price;
        }
    }
}
