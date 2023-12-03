using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aoc2023.Day01
{
    public partial class Day01{
        
        
        
        
        public static string Part1(){
            using StreamReader reader = new StreamReader("Day01/input.txt");
            string input = reader.ReadToEnd();

            string[] lines = input.Split("\n");
            Regex regex = new Regex(@$"(\d)");
            MatchCollection matches;
            int res = 0;

            foreach(string line in lines){
                Console.WriteLine(line);
                matches = regex.Matches(line);
                
                res += int.Parse(matches.First().Groups[0].Value + matches.Last().Groups[0].Value); 
               
            }




            return res.ToString();
        }

        
    }
}