using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Aoc2023.Day03
{
    public class Gear
        {
            public int NbValve{get; set;}
            public int Ratio{get; set;}
        }
    public partial class Day03{
        
        public static string Part2(){
            using StreamReader reader = new StreamReader("Day03/input.txt");
            string input = reader.ReadToEnd();

            string[] lines = input.Split("\r\n");
            
            Dictionary<string, Gear> resultDict = new Dictionary<string, Gear>();
            
            string currentNumber = "";
            int res = 0;
            int iLast = 0;
            int jLast = 0;
            string resultNextToSymbol;
            
            for(int i = 0; i < lines.Length;i++){
                for(int j = 0; j < lines[i].Length; j++){
                    if(number.Contains(lines[i][j])){
                        currentNumber += lines[i][j];
                        iLast = i;
                        jLast = j;
                    }else{
                        if(currentNumber != ""){
                            resultNextToSymbol =  NextToSymbolP2(lines, iLast , jLast, currentNumber.Length);
                            if(resultNextToSymbol != ""){
                                if(resultDict.ContainsKey(resultNextToSymbol)){
                                    resultDict[resultNextToSymbol].NbValve ++;
                                    resultDict[resultNextToSymbol].Ratio *= int.Parse(currentNumber);
                                }else{
                                    resultDict.Add(resultNextToSymbol,new Gear{NbValve = 1, Ratio = int.Parse(currentNumber)});
                                }
                            }
                            currentNumber = "";
                        }
                        
                    }
                }
            }

            foreach(string key in resultDict.Keys){
                if(resultDict[key].NbValve == 2){
                    res += resultDict[key].Ratio;
                }
            }

            return res.ToString();
        }


        public static string NextToSymbolP2(string[] lines, int i, int j, int length){
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
                    if((lines[k][l] != '.') & ((k != i) | ((k == i) & ((l == j-length) | (l == j+1)))) & (lines[k][l] == '*'))
                        return k.ToString("000")+l.ToString("000");
                }
            }



            return "";
        }
    }




}