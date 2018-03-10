using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    [Serializable]
   public class BowlingException : Exception
    {

       public string ExtraErrorInfo { get; set; } 
       public BowlingException() : base() { }
       public BowlingException(string message) : base(message) { }
       public BowlingException(string message, Exception e) : base(message, e) { }      

   }
}
