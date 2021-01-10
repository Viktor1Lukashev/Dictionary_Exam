using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.UserExeption
{
  public class ContainsElemExeption: Exception
    {
        public ContainsElemExeption(string ex):base(ex)
        {
            
        }

     }

    }