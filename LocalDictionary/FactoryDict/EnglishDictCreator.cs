using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    public class EnglishDictCreator : FactoryDict
    {

        public AbstractUserDictionary Create(string path)
        {
            return new EnglishRussian(path);
        }

    }
}
