using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.Json;

namespace Aoc2023.Day02
{
    public partial class Day02{
        
        
        
        
        public static string Part1(){
            using StreamReader reader = new StreamReader("Day02/input.txt");
            string input = reader.ReadToEnd();

            string[] lines = input.Split("\r\n");
            Regex regex = new Regex(@$"(?:\w+) (?'id'\d*)(?:(?:,|;|:) (?'number'\d*) (?'color'\w*))*");
            Match matches;
            int res = 0;

            Dictionary<string, int> maxCube = new Dictionary<string, int>{
                {"red", 12},
                {"green", 13},
                {"blue", 14}
            };
            Boolean valid;
            foreach(string line in lines){
                Console.WriteLine(line);
                matches = regex.Match(line);
                valid = true;
                for(int i = 0; i < matches.Groups["color"].Captures.Count(); i++){
                    if(maxCube[matches.Groups["color"].Captures[i].Value] < int.Parse(matches.Groups["number"].Captures[i].Value)){
                        valid = false;
                        Console.WriteLine(maxCube[matches.Groups["color"].Captures[i].Value].ToString());
                        Console.WriteLine(matches.Groups["number"].Captures[i].Value);
                    }
                }

                if(valid)
                    res += int.Parse(matches.Groups["id"].Value);
                
            }




            return res.ToString();
        }

        
    }
}