using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exam
{
    class EnglishRussian : AbstractUserDictionary, Idict
    {
        public EnglishRussian(string path) : base(path) { }
        public EnglishRussian() : base() { }
        public override void CheckValueCorrect(string word)
        {
            Regex UserRegex = new Regex("^[А-Яа-яЁё]{2,}$");
            if (UserRegex.IsMatch(word))
            {
                throw new ErrorCharExeption($"в данном слове должны быть только английские символы. Слово {word} не будет добавлено в словарь!",word);
            }
        }     
        public override void CheckValuesCorrect(string word, string translate)
        {
            Regex rx = new Regex(@"^[a-zA-Z]{2,}$");
            Regex rx2 = new Regex("^[А-Яа-яЁё]{2,}$");
           

            if(!rx.IsMatch(word)) //перегруженный метод для изменения слова
            {
                throw new ErrorCharExeption($"в данном слове должны быть только английские символы. Слово - {word} не будет изменено!", word);
            }

            if(!rx2.IsMatch(translate)) 
            {
                {
                    throw new ErrorCharExeption($"в данном слове должны быть только русские символы. Данный переводn - {translate} не будет добавлен", translate);
                }

            }
        }
    }
}
