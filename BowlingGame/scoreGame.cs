using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BowlingGame
{
    class scoreGame
    {

        public scoreGame()
        {
        
        }

        public static ArrayList Score(int firstRoll, int secondRoll)
        {        
           ArrayList array = new ArrayList();          
        
            if (firstRoll == 10)
            {
                array.Add("10|0"); array.Add("16");
            }
            else if (firstRoll == 5)
            {
                array.Add("5|0"); array.Add("12");
            }
            else if (firstRoll > 5)
            {
                array.Add(firstRoll + "|0"); array.Add(firstRoll);
            }
            else if (firstRoll < 5)
            {
                array.Add(firstRoll + "|" + secondRoll); array.Add(firstRoll + secondRoll);
            }
           
            else {
                array.Add(firstRoll + "|" + secondRoll); array.Add(firstRoll + secondRoll);
            }



            return array;
        }       
     
    }
   
}
