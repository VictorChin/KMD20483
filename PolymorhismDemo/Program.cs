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
            Garage myGarage = new Garage();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (r.Next(10) % 3)
                {
                    case 0:
                        myGarage.Park(new LuxurySedan() { mileage = r.Next(1000) } );
                        break;
                    case 1:
                        myGarage.Park(new SportsCar(){ mileage = r.Next(1000) } );
                    break;
                    case 2:
                        myGarage.Park(new Sedan() { mileage = r.Next(1000) });
                        break;
                }
            }
            var iter = myGarage.GetEnumerator();
            while (iter.MoveNext())
            {
                Console.WriteLine($"{iter.Current} : Mileage {iter.Current.mileage} ");
            }

            
        }
    }
}
