using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SimulatedScores
{
   class Program
   {
      static void Main(string[] args)
      {
         var names = args.ToList();
         if (!names.Any())
         {  //If no names provided via command arguments, let's use these 40 names
            names = new List<string>( new[] { "Adam", "Alex", "Alice", "Anne", "Andy", "Anthony", "Ashley", "Betty", "Bob", "Brian",
                                              "Chuck", "Cora", "Daniel", "David", "Eddie", "Emily", "Emma", "Evan", "George", "Greg",
                                              "Harry", "Jason", "Jennifer", "Jim", "Joe", "John", "Josh", "Linda", "Lisa", "Luke",
                                              "Maggie", "Mark", "Mary", "Paula", "Ruth", "Ryan", "Steve", "Sue", "Tom", "Zach" } );
         }

         var stopWatch = new Stopwatch();
         stopWatch.Start();

         int count = 0;
         int totalScore = 0;
         foreach (var name in names)
         {
            var age = ObtainAge(name);
            //Millenials are those between the ages of 23 and 37 (as of 2019)
            if (23 <= age && age <= 37)
            {
               count++;
               totalScore += ObtainScore(name);
            }
         }
         Console.WriteLine($"Average score for the {count} millenials is {(double)totalScore / count:###.#}");

         stopWatch.Stop();
         Console.WriteLine($"Processing completed in {stopWatch.Elapsed.TotalSeconds.ToString("##0.000")}s");
      }

      /// <summary>
      /// Obtains person's age (using contrived calculations).
      /// </summary>
      /// <param name="name">Name of a person.</param>
      /// <returns>Person's age.</returns>
      static int ObtainAge(string name)
      {
         //Age is a value in a range of 18-80
         var age = name.Sum(l => l) % 63 + 18;  // l = letter in the name

         return age;
      }

      /// <summary>
      /// Obtains person's hypothetical score value (using contrived calculations).
      /// </summary>
      /// <param name="name">Name of a person.</param>
      /// <returns>Person's score.</returns>
      static int ObtainScore(string name)
      {
         //Score is calculated as a value in a range of 350-800
         int i = 0;
         var score = name.Sum(l => { Thread.Sleep(10); return l * (4 - i++ % 4); }) % 551 + 300;

         return score;
      }

   }
}
