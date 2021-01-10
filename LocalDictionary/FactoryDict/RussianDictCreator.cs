using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    public class RussianDictCreator : FactoryDict
    {
        

        public AbstractUserDictionary Create(string path)
        {
            return new RussianEnglish(path);
        }

    }
}