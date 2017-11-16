using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        Dictionary<string,int> results = new Dictionary<string, int>();
        Dictionary<string,SortedSet<string>> categories = new Dictionary<string, SortedSet<string>>();

       
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            var token = input.Split(' ');
            var name = token[0];
            var category = token[1];
            var score = int.Parse(token[2]);

            if (!results.ContainsKey(name))
            {
                results[name] = 0;
            }
            if (!categories.ContainsKey(name))
            {
                categories[name] = new SortedSet<string>();
            }

            results[name] += score;
            categories[name].Add(category);
        }

        var orderResult = results
            .OrderByDescending(p => p.Value)
            .ThenBy(p => p.Key);

        foreach (var person in orderResult)
        {
            string name = person.Key;
            int points = person.Value;
            var listOfCategories = string.Join(", ", categories[name]);
            Console.WriteLine($"{person.Key}: {person.Value} [{listOfCategories}]");
        }
    }
}