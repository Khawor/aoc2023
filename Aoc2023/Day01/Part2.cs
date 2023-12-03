using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aoc2023.Day01
{
    public partial class Day01{
        public static string Part2(){
             using StreamReader reader = new StreamReader("Day01/input.txt");
            string input = reader.ReadToEnd();
            string[] lines = input.Split("\r\n");

            Dictionary<string, string> digits = new Dictionary<string, string>{
                {"one", "1"},
                {"two", "2"},
                {"three", "3"},
                {"four", "4"},
                {"five", "5"},
                {"six", "6"},
                {"seven", "7"},
                {"eight", "8"},
                {"nine", "9"},
                {"1", "1"},
                {"2", "2"},
                {"3", "3"},
                {"4", "4"},
                {"5", "5"},
                {"6", "6"},
                {"7", "7"},
                {"8", "8"},
                {"9", "9"}
            };

            Regex regex = new Regex(@$"(?<=(one|three|four|five|six|seven|eight|two|nine|\d))");

            MatchCollection matches;
            int res = 0;
            int temp;
            foreach(string line in lines){
                // Console.WriteLine(line);
                matches = regex.Matches(line);
                
                temp = int.Parse(digits[matches.First().Groups[1].Value] + digits[matches.Last().Groups[1].Value]); 
                Console.WriteLine(line + " - "+temp.ToString());
                res += temp;
            }


            return res.ToString();
        }
    }
}