using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorhismDemo
{
    class Sedan:Car
    {
        public override void Drive()
        {
            Console.WriteLine("Sedan Driving");
        }
        public override void PrintGas()
        {
            Console.WriteLine("I run on 87 petro");

        }
    }
}
