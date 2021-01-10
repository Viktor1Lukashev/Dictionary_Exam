using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.UserExeption
{
  public  class ExeptionChoiseDictionary:Exception
    {
        public ExeptionChoiseDictionary(string s) : base(s) { }
    }
}
