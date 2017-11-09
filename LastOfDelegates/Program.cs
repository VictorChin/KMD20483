using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastOfDelegates
{
    class Program
    {
        static void DisplayProcesses(Predicate<Process> match)
        {
            var processes = new List<ProcessData>();
            foreach (var process in Process.GetProcesses())
            {
                if (match(process))
                {
                    processes.Add(new ProcessData
                    {
                        Id = process.Id,
                        Name = process.ProcessName,
                        Memory = process.WorkingSet64
                    });
                }
            }

            Console.WriteLine("Total memory: {0} MB",
              processes.TotalMemory() / 1024 / 1024);
            Queue<ProcessData> q = new Queue<ProcessData>();
            Console.WriteLine(q.TotalMemory());  
            var top2Memory =
              processes
                .OrderByDescending(process => process.Memory)
                .Take(2)
                .Sum(process => process.Memory) / 1024 / 1024;
            Console.WriteLine(
              "Memory consumed by the two most hungry processes: {0} MB",
              top2Memory);

        }

        static void Main()
        {
            string pname = "notepad";
            DisplayProcesses(process => process.WorkingSet64 >= 20 * 1024 * 1024);
           
            DisplayProcesses(p => p.ProcessName.Contains(pname));
        }

       
    }// Temporary hack to enable extension methods

    public class ProcessData
    {
        public Int32 Id { get; set; }
        public Int64 Memory { get; set; }
        public String Name { get; set; }
    }

    static class Extensions
    {
        internal static Int64 TotalMemory(this IEnumerable<ProcessData> processes)
        {
            Int64 result = 0;
            foreach (var process in processes)
                result += process.Memory;
            return result;
        }
    }
}
