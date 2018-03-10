using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BowlingGame;

namespace BowlingMain
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new ConsoleText();
            }
            catch (BowlingException e)
            {
                Console.Write("Error: {0}", e.ExtraErrorInfo);
            }
        }
    }
}
