using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
   public class Player
    {
       static List<string> _lstPlayers;
       public string name { get; set; }
       public int score { get; set; }
       public int scoreTotal { get; set; }
       static List<KeyValuePair<string, int>> _lstPlayerScore = new List<KeyValuePair<string, int>>();

       public Player() {
           _lstPlayers = Util.lstNamePlayers;
       }

       public static void NumHitsPlayer(List<string> lst)
       {
           int score = 0, _numHit = 0;
           string x = lst[Util.numPlayer];


           SetPositionScore(lst, lst[Util.numPlayer], Util.numColumn);
           if (Util.numColumn == 11) ConsoleText.GameOver();

           do
           {
               _numHit = Util.numHit;
               string scoreAux = ConsoleText.PositionText(lst);
               if (!int.TryParse(scoreAux, out score))
               {
                   score = -1;
               }

               if (score >= 0 && score <= 10)
               {
                   string str = (_numHit == 0) ? "FirstHit" + lst[Util.numPlayer] + Util.numColumn : "SecondtHit" + lst[Util.numPlayer] + Util.numColumn;
                   _lstPlayerScore.Add(new KeyValuePair<string, int>(str, score));
                   _numHit++;

               }
               if (score < 0 || score > 10 || _numHit != 2)
               {
                   Util.numHit = _numHit;
                   Console.Clear();
                   new ConsoleFrame(lst);
               }
           }
           while ((score < 0 || score > 10) || _numHit != 2);

           string patternSearch = lst[Util.numPlayer] + Util.numColumn;
           List<KeyValuePair<string, int>> resultFindAll = _lstPlayerScore.FindAll(
                   delegate(KeyValuePair<string, int> current)
                   {
                       return current.ToString().Contains(patternSearch);
                   }
            );

           string numSearched1 = "FirstHit" + lst[Util.numPlayer] + Util.numColumn;
           var num1 = resultFindAll.Find(p => p.Key == numSearched1);
           string numSearched2 = "SecondtHit" + lst[Util.numPlayer] + Util.numColumn;
           var num2 = resultFindAll.Find(p => p.Key == numSearched2);
           int result = num1.Value + num2.Value;

           foreach (var p in Util.lstPlayerScore)
           {
               if (p.name.Contains(lst[Util.numPlayer]))
               {
                   p.scoreTotal += result; break;
               }
           }


           resultFindAll.Add(new KeyValuePair<string, int>("result" + lst[Util.numPlayer] + Util.numColumn, result));
           Util.dcPlayerScore.Add(lst[Util.numPlayer] + Util.numColumn, resultFindAll);

           Util.numPlayer++;
           Util.numHit = 0;

           if (Util.numPlayer < lst.Count)
               new ConsoleFrame(lst);
           else
           {
               Util.numPlayer = 0;
               Util.numColumn++;
               new ConsoleFrame(lst);
           }
       }

       private static void SetPositionScore(List<string> lst, string currentPlayer, int column)
       {
           string first = ""; string second = ""; string result = "";
           int leftPosition = 0, topPosition = 6;


           foreach (var items in Util.dcPlayerScore)
           {

               if (items.Key.Contains("1")) { leftPosition = 23; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("2")) { leftPosition = 31; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("3")) { leftPosition = 39; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("4")) { leftPosition = 47; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("5")) { leftPosition = 55; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("6")) { leftPosition = 63; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("7")) { leftPosition = 71; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("8")) { leftPosition = 79; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("9")) { leftPosition = 87; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }
               if (items.Key.Contains("10")) { leftPosition = 95; if (topPosition == 11 || topPosition == 16) { } else topPosition = 6; }


               foreach (var itemsPlayerValues in items.Value)
               {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.SetCursorPosition(leftPosition, topPosition);                   

                   if (itemsPlayerValues.Key.Contains("FirstHit"))
                       first = itemsPlayerValues.Value.ToString();
                   if (itemsPlayerValues.Key.Contains("SecondtHit"))
                       second = itemsPlayerValues.Value.ToString();

                   Console.Write(first + "|" + second);
                   if (itemsPlayerValues.Key.Contains("result"))
                       result = itemsPlayerValues.Value.ToString();

                   Console.SetCursorPosition(leftPosition + 1, topPosition + 1);

                   Console.Write(result);
                   Console.ForegroundColor = ConsoleColor.White;

               }

               topPosition += 5;

               if (lst.Count == 2 && topPosition == 16) topPosition = 6;
           }

       }
    }
}
