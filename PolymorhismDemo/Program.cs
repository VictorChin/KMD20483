using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorhismDemo
{
    enum PinLayout
    {
        ThreeProngUK,
        TwoProngEU,
        TwoProngUS,
    }
    interface ISocket
    {
        PinLayout GetPinLayout();
        
    }
    struct Point
    {
        public int x, y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point one = new Point { x = 10, y = 10 };
            
            //object b =one; //boxing
            //Point two = (Point)b; //unboxing
            //one.x = 100;
            //Console.WriteLine(two.x);
            List<ICar> a = new List<ICar>();
            Garage myGarage = new Garage();
            myGarage.CarParked += (theCar) =>
            {
                Console.WriteLine("Garage saw a new car coming in.");
                Console.WriteLine($"I see its event.{theCar.mileage}");
                return (theCar.mileage > 500);
            };
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
            //var iter = myGarage.GetEnumerator();
            //while (iter.MoveNext())
            //{
            //    Console.WriteLine($"{iter.Current} : Mileage {iter.Current.mileage} ");
            //}
            foreach (var item in myGarage)
            {
                Console.WriteLine($"{item} : Mileage {item.mileage} ");
            }

            
        }

       
    }
}
