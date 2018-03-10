using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BowlingGame
{
   public class ConsoleText
    {

       static List<string> _lstPlayers; 
       public ConsoleText() {
           Util.leftPosition = 23;
           Util.numColumn = 1;
          
           NumPlayer();
           new ConsoleFrame(_lstPlayers);
       }
       private static void NumPlayer()
        {
            try
            {
                int numPlayer = 0;
                Console.WriteLine("The current console title is: \"{0}\"",
                         Console.Title);
                Console.SetWindowSize(108, 40);

                do
                {
                    Console.Clear();
                    Console.Write(" Please enter the number of players (1-3): ");
                    string numPlayerAux = Console.ReadLine();
                    if (!int.TryParse(numPlayerAux, out numPlayer))
                    {
                        numPlayer = 0;
                    }
                }
                while (numPlayer < 1 || numPlayer > 3);

                _lstPlayers = NamePlayer(numPlayer);
            }
            catch (BowlingException e)
            {
                e.ExtraErrorInfo = "Error in ConsoleText.NumPlayer()";
                throw e;
            }
        }

        private static List<string> NamePlayer(int numPlayer)
        {
            try
            {
                List<string> lstNames = new List<string>();
                string name = "";


                for (int y = 1; y <= numPlayer; y++)
                {

                    Console.Write(" Please enter a name for player {0} :", y);
                    name = Console.ReadLine();

                    while (name.Length < 3 || name.Length > 12)
                    {
                        Console.Clear();
                        Console.WriteLine(" Name must be between 3 and 12 characters long.");
                        Console.Write(" Please enter a name for player {0} :", y);
                        name = Console.ReadLine();
                    };

                    lstNames.Add(name);

                    Player player = new Player();
                    player.name = name;
                    Util.lstPlayerScore.Add(player);
                }                

                return lstNames;
            }
            catch (BowlingException e) {
                e.ExtraErrorInfo = "Error in ConsoleText.NamePLayer()";
                throw e;
            }
        
        }     

      
        public static void GameOver()
        {
            try
            {
                var maxValue = Util.lstPlayerScore.Max(x => x.scoreTotal);
                var maxValueName =
                                    from p in Util.lstPlayerScore
                                    group p by p.name into g
                                    select new { Name = g.Key, scoreTotal = g.Max(p => p.scoreTotal) };

                string sName = "";
                foreach (var a in maxValueName)
                    if (maxValue == a.scoreTotal)
                        sName = a.Name;


                Console.SetCursorPosition(2, 22);
                Console.Write("\n\n");
                Console.Write("  GAME OVER\n\n ");
                Console.WriteLine("  The winner is {0} with {1} points\n", sName, maxValue);
                Console.Write("    Would you like to play again (y/n)?");
                string answer = Console.ReadLine();

                ClearFields();

                _lstPlayers = Util.lstNamePlayers;
                NumPlayer();
                new ConsoleFrame(_lstPlayers);
            }
            catch (BowlingException e)
            {
                e.ExtraErrorInfo = "Error in ConsoleText.GameOver()";
                throw e;
            }
            
        }

        private static void ClearFields()
        {
            Util.dcPlayerScore.Clear();           
            Util.dcScoreTotal.Clear();
            Util.lstPlayers.Clear();
            Util.lstPlayerScore.Clear();
            Util.numColumnAux = 0;
            Util.leftPosition = 23;
            Util.numColumn = 1;
            Util.numHit = 0;
            Util.numPlayer = 0;
            Util.scoreTotal = 0;
        }

       

        public static string PositionText(List<string> lst)
        {
            try
            {
                PositionTextFrame(lst);

                Console.Write("Current player is: {0}", lst[Util.numPlayer]);
                Console.Write("\n\n");
                Console.Write("  How many pins do you want hit? ");

                return Console.ReadLine();
            }
            catch (BowlingException e)
            {
                e.ExtraErrorInfo = "Error in ConsoleText.PositionText()";
                throw e;
            }
        }

        private static void PositionTextFrame(List<string> lst)
        {
            if (lst.Count == 3)
                Console.SetCursorPosition(2, 25);
            else if (lst.Count == 2)
                Console.SetCursorPosition(2, 20);
            else if (lst.Count == 1)
                Console.SetCursorPosition(2, 15);
        }
    }
}
