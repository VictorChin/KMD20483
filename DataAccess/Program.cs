using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };

            // Group words by length
            var groups =
              from word in words
              orderby word ascending
              group word by word.Length into lengthGroups
              orderby lengthGroups.Key descending
              select new { Length = lengthGroups.Key, Words = lengthGroups };
            // Print each group out
            foreach (var group in groups)
            {
                Console.WriteLine("Words of length " + group.Length);
                foreach (string word in group.Words)
                    Console.WriteLine("  " + word);
            }

            var procs = Process.GetProcesses();

            IQueryable<Process> result =
                (from p in procs
                where (p.WorkingSet64 > 100000) && (p.ProcessName=="notepad")
                select p).AsQueryable<Process>();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProcessName} : {item.Id}");
            }
            Console.ReadLine();
        }
    }
}
