using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            var info = ObtainInfo(name);

            //Millenials are those between the ages of 23 and 37 (as of 2019)
            if (23 <= info.Age && info.Age <= 37)
            {
               count++;
               totalScore += info.Score;
            }
         }
         Console.WriteLine($"Average score for the {count} millenials is {(double)totalScore / count:###.#}");

         stopWatch.Stop();
         Console.WriteLine($"Processing completed in {stopWatch.Elapsed.TotalSeconds.ToString("##0.000")}s");
      }

      /// <summary>
      /// Obtains person's age and a hypothetical score value (using contrived calculations).
      /// </summary>
      /// <param name="name">Name of a person.</param>
      /// <returns>Tuple containing age and score.</returns>
      static (int Age, int Score) ObtainInfo(string name)
      {
         //Age is a value in a range of 18-80
         var age = name.Sum(l => l) % 63 + 18;  // l = letter in the name

         //Score is calculated as a value in a range of 350-800
         int i = 0;
         var score = name.Sum(l => l * (4 - i++ % 4)) % 551 + 300;

         return (age, score);
      }

   }
}
