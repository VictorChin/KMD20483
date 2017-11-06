using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> {"Tenna","Soren","Soley","Lana","Morten"  };
            Console.WriteLine(names.Count);
            Console.WriteLine(names[2]);
            Console.WriteLine(names.IndexOf("Lana"));
            names.Insert(3, "Victor");
            names.Sort();
            Console.WriteLine(names.IndexOf("Lara"));
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            //Generate Fib Sequence
            List<int> fib = new List<int>() { 0,1};
            for (int i = 1; i <= 20; i++)
            {
                fib.Add(fib[i]+fib[i-1]);
            }
            fib.RemoveRange(0, 2);
            Console.WriteLine(fib.Count);
            foreach (var item in fib)
            {
                Console.WriteLine(item);
            }
        }
    }
}
