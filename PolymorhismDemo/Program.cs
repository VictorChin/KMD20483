using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorhismDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> a = new List<Car>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (r.Next(10) % 3)
                {
                    case 0:
                        a.Add(new LuxurySedan() { mileage = r.Next(1000) } );
                        break;
                    case 1:
                        a.Add(new SportsCar(){ mileage = r.Next(1000) } );
                    break;
                    case 2:
                        a.Add(new Sedan() { mileage = r.Next(1000) });
                        break;
                }
            }
            a.Sort(new MileageDESCComparer());

            using (a[0])
            {
                a[0].Drive();
            }
        }
    }
}
