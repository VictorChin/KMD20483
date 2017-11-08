using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorhismDemo
{
    abstract class Car : IComparable<Car>,IDisposable
    {
        public virtual void Drive() { Console.WriteLine("Car Driving"); }
        public virtual void Drive(int x) { Console.WriteLine($"Car Driving:{x}"); }
        public abstract void PrintGas();

        public int CompareTo(Car other)
        {
           return this.mileage - other.mileage;
        }

        public void Dispose()
        {
            Console.WriteLine("release memory");
        }

        public int mileage;
    }
}
