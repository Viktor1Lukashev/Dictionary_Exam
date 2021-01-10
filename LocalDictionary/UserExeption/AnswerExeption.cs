using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
   public class AnswerExeption:Exception
    {
       public AnswerExeption(string Message) : base(Message) { }
    }
}
