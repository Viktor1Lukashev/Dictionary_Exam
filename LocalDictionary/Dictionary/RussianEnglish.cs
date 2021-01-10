using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exam
{
 public class RussianEnglish: AbstractUserDictionary,Idict
    {
        
        public RussianEnglish() : base() { }
        public RussianEnglish(string path): base(path) { }
        public override void CheckValueCorrect(string word)
        {
            Regex rx = new Regex("[a-zA-Z]");
            if (!rx.IsMatch(word))
            {
                throw new ErrorCharExeption("в данном слове должны быть только английские символы. Слово не будет добавлено в словарь!", word);
            }
        }
        public override void CheckValuesCorrect(string word, string translate)
        {
            Regex rx = new Regex(".*[А-яЁё].*");
            Regex rx2 = new Regex("[a-zA-Z]");
           
                if (!rx.IsMatch(word))
                {
                    throw new ErrorCharExeption($"в данном слове должны быть только английские символы. Слово {word} не будет добавлено в словарь!", word) ;
                }
                      
                if(!rx2.IsMatch(translate))
                {
                    {
                        throw new ErrorCharExeption("в данном слове должны быть только английскийе символы. Данный перевод не будет добавлен", translate);
                    }             
            }
        }
    }
}
