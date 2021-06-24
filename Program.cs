using System;
using System.Collections.Generic;
using System.Linq;

namespace Sheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrTasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] arrThreads = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> tasks = new Stack<int>(arrTasks);
            Queue<int> threads = new Queue<int>(arrThreads);

            int numbToKill = int.Parse(Console.ReadLine()); // check is it input int ? Try.Parse()

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int stackTopElement = tasks.Peek();
                int queFirstElem = threads.Peek();

                if (numbToKill == stackTopElement)
                {
                    Console.WriteLine($"Thread with value {queFirstElem} killed task {numbToKill}");

                    Console.WriteLine(String.Join(" ", threads));

                    break;
                }

                if (queFirstElem >= stackTopElement)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (queFirstElem < stackTopElement)
                {
                    threads.Dequeue();
                }               
            }            
        }
    }
}
