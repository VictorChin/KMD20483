using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorhismDemo
{
    class MileageASCComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return x.mileage - y.mileage;
        }
    }
    class MileageDESCComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return  y.mileage - x.mileage;
        }
    }
}
