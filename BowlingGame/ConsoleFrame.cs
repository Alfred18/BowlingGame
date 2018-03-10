using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
   public class ConsoleFrame
    {
       public ConsoleFrame(List<string> lstNamePlayers) {
           Frame(lstNamePlayers);
       }

       protected void Frame(List<string> lstNamePlayers)
       {
           try
           {
               int width, height;
               height = lstNamePlayers.Count * 5;
               width = 50;

               Console.Clear();
               Console.Write("\n");
               Console.Write("   Name Players");

               int countLine = 1, num = 4;
               for (int i = 0; i <= 51; i++)
               {
                   if (i == num && countLine < 11)
                   {
                       Console.Write(" " + countLine);
                       num += 4;
                       countLine++;
                   }
                   else
                       Console.Write("  ");

               }

               Console.Write("\n");
               Console.Write(" ");

               for (int y = 0; y != width; y++)
                   Console.Write("__");


               for (int y = 1; y <= height; y++)
               {
                   Console.Write("\n");
                   LineHorizontal(width, y, lstNamePlayers.Count);
               }

               Console.Write("\n|");
               for (int aux = 0; aux != width; aux++)
                   Console.Write("__");


               Console.Write('|');
               Console.Write("\n\n");
               SetName(lstNamePlayers);
               Player.NumHitsPlayer(lstNamePlayers);
           }
           catch (BowlingException e)
           {
               e.ExtraErrorInfo = "Error in ConsoleFrame.Frame()";
               throw e;
           }
        
       }

       private void SetName(List<string> lstNamePlayers)
       {
           int positionName = 5;
           for (int y = 0; y < lstNamePlayers.Count; y++)
           {
               Console.ForegroundColor = ConsoleColor.DarkYellow;
               Console.SetCursorPosition(4, positionName);
               Console.Write(lstNamePlayers[y]);
               positionName += 6;
           }
           Console.ForegroundColor = ConsoleColor.White;
       }   

       private void LineHorizontal(int width, int y,int count)
       {

           if ((y == 6 || y == 11) && y < (count * 5)  )
           {
               Console.Write(" ");
               for (int i = 0; i < width; i++)
                   Console.Write("--");

               Console.Write("\n");           

           }        
                
           int countLine = 10;
           for (int i = 0; i <= 51; i++)
           {

               if (i == 0 || i == countLine)
               {
                   if (i > 0 && i < 46) countLine += 4;
                   Console.Write("|");
                   Console.Write(" "); 
               }
               else if (i == 50)
               {
                   Console.Write(" "); 
                   Console.Write("|");
                  
               }
               else
                   Console.Write("  ");
           }         
           
       }      
      
    }
}
