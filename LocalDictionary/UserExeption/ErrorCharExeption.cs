using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
   public class ErrorCharExeption:Exception
    {
        public string Val { get; private set; }

      public  ErrorCharExeption(string s,string val):base(s)
        {
            Val = val;
        }
    }
}
