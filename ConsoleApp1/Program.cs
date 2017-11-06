using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int min=1, max = 100,maxtry=6,tryCount=0;
            bool isContinue = false;
            Random r = new Random();
            int answer = r.Next(min, max);
            Console.WriteLine($"I am thinking of a number between {min} and {max}");
            do
            {
                int guess=0;
                Console.WriteLine("Please enter your guess:");
                if (!int.TryParse(Console.ReadLine(), out guess))
                {  Console.WriteLine("Thats not a number");
                    isContinue = true;
                    continue;
                }
              //tr isContinue = true;xy
              //   continue;{
              //      guess = int.Parse(Console.ReadLine());
              //  }
              //  catch (Exception)
              //  {
              //      Console.WriteLine("Thats not a number");
              //      isContinue = true;x
              //      continue;
              //  }
                
                if (guess==answer)
                {
                    Console.WriteLine($"You got it, the answer is {answer}!");
                    break;
                }
                else
                {
                    if (guess > answer)
                        { Console.WriteLine("too high"); }
                    else
                        { Console.WriteLine("too low"); }
                    if (tryCount == maxtry-1)
                    {
                        Console.WriteLine($"You are out of tries, the answer is {answer}");
                        break; }
                    tryCount++;
                    Console.WriteLine($"You have {maxtry-tryCount} tries left");
                    isContinue = true;
                }
            } while (isContinue);

        }
    }
}
