﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorhismDemo
{
    class SportsCar:Car
    {
        public override void PrintGas()
        {
            Console.WriteLine("I run on rocket fuel");
        }
    }
}
