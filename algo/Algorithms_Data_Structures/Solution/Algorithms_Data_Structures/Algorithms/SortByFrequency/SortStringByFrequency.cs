using System.Collections.Generic;
using System.Linq;

namespace Algorithms_Data_Structures.Algorithms.SortByFrequency
{
    public static class SortStringByFrequency
    {
        public static string Sort(string text) 
        {
            var charResult = new char[text.Length];
            var iResult= 0;
            var charCounts = new Dictionary<char, int>();

            // Store chartCounts
            foreach (var c in text)
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts.Add(c, 1);
                }
            }

            // Order chartCounts by frequency in desc order 
            charCounts = charCounts.OrderByDescending(c => c.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            // Create charResult
            foreach (var item in charCounts)
            {
                var count = item.Value;
                do
                {
                    charResult[iResult++] = item.Key;
                    count--;
                } while (count > 0);
            }

            return new string(charResult);
        }
    }
}