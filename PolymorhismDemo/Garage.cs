﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorhismDemo
{
    class Garage : IEnumerable<Car>
    {
        private List<Car> _cars = new List<Car>();

        public void Park(Car aCar)
        {
            _cars.Add(aCar);
        }

        public Car Fetch(int i)
        {
            _cars.RemoveAt(i);
            return _cars[i];
        }
          
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        public IEnumerator<Car> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }
    }
}
