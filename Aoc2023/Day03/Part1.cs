using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.Json;

namespace Aoc2023.Day03
{
    public partial class Day03{
        
        
        public const string number = "0123456789";
        
        public static string Part1(){
            using StreamReader reader = new StreamReader("Day03/input.txt");
            string input = reader.ReadToEnd();

            string[] lines = input.Split("\r\n");
            
            
            
            string currentNumber = "";
            int res = 0;
            int iLast = 0;
            int jLast = 0;
            
            for(int i = 0; i < lines.Length;i++){
                for(int j = 0; j < lines[i].Length; j++){
                    if(number.Contains(lines[i][j])){
                        currentNumber += lines[i][j];
                        iLast = i;
                        jLast = j;
                    }else{
                        if(currentNumber != ""){
                            if(NextToSymbol(lines, iLast , jLast, currentNumber.Length)){
                                Console.WriteLine(currentNumber);
                                
                                res += int.Parse(currentNumber);
                            }
                            currentNumber = "";
                        }
                        
                    }
                }
            }
            
            return res.ToString();
        }

        public static Boolean NextToSymbol(string[] lines, int i, int j, int length){
            //au bord
            int startk = i-1;
            int finishk = i+1;
            int startl = j-length;
            int finishl = j+1;

            if(i == 0)
                startk = 0;
            if (j-length == -1)
                startl = 0;
            if(i+1 == lines.Length)
                finishk = i;
            if(j+1 >= lines[i].Length)
                finishl = j;


            for(int k = startk;k <= finishk; k++ ){
                Console.WriteLine(lines[k]);
                for(int l = startl;l <= finishl; l++){
                    if((lines[k][l] != '.') & ((k != i) | ((k == i) & ((l == j-length) | (l == j+1)))))
                        return true;
                }
            }



            return false;
        }

        
    }
}