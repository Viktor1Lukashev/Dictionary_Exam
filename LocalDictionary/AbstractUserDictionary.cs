using exam.UserExeption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//сделать чтобы перед добавлением слова в dictionary при считывании из файла он сначала проверялся через регулярное выражение.
namespace exam
{
   public abstract class AbstractUserDictionary:Idict
    {
        protected string _Path;
        protected SortedDictionary<string, List<string>> _UserDictionary;
        public AbstractUserDictionary() {
            _UserDictionary = new SortedDictionary<string, List<string>>();
            _Path = "dict";
        }
        protected bool IsContain(string value)
        {
            if (_UserDictionary.ContainsKey(value))
            {
                return true;
            }
            return false;
        }
        public void SaveInFile()
        {
            using (FileStream stream = new FileStream(_Path, FileMode.Create))
            {
                using (StreamWriter WriteStream = new StreamWriter(stream, Encoding.UTF8))
                {

                    foreach (KeyValuePair<string, List<string>> k in _UserDictionary)
                    {                       
                        WriteStream.Write(k.Key+":");                        
                        foreach (var i in _UserDictionary[k.Key])
                        {
                            WriteStream.Write(i+";");                            
                        }
                        WriteStream.WriteLine();
                    }                   
                }
            }
        }   
        public void PrintDictionaryValues()
        {
            foreach (KeyValuePair<string, List<string>> DictValues in _UserDictionary)
            {
                Console.Write(DictValues.Key +'-');
                foreach (var Value in _UserDictionary[DictValues.Key])
                {
                    Console.Write(Value + ';');
                }
                Console.WriteLine();
            }            
        } 
        private void ReadFromFile(StreamReader StreamForRead)
        {
            while (!StreamForRead.EndOfStream)
            {
                string[] SplitStrings = StreamForRead.ReadLine().Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                string key = SplitStrings[0];
                List<string> ValuesForDictionary = new List<string>();
                for (int i = 1; i < SplitStrings.Count(); ++i)
                {
                    ValuesForDictionary.Add(SplitStrings[i]);
                }
                _UserDictionary.Add(key, ValuesForDictionary);
            }
        }
        public AbstractUserDictionary(string path)
        {
            _Path = path;
            try {
                using (FileStream stream = new FileStream(_Path, FileMode.OpenOrCreate))
                {
                    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    {

                        _UserDictionary = new SortedDictionary<string, List<string>>();

                        ReadFromFile(sr);
                    }
                }
            }          
           catch(Exception ex)
            {
                throw;
            }
        }
        public void AddToDictionary(string word, string translate)
        {
            CheckValuesCorrect(word, translate);
            string FormattingWord = word.ToLower().Trim();
            string FormattingTranslate = translate.ToLower().Trim();
            try
            {               
                if (_UserDictionary.ContainsKey(FormattingWord))
                {
                    foreach (var c in _UserDictionary[word] )
                    {
                        if(c == FormattingTranslate)
                        {
                            throw new ContainsElemExeption($"{FormattingTranslate} - данный перевод слова '{FormattingWord}' уже имеется в словаре, поэтому перевод не будет добавлен!" );
                        }
                    }
                        _UserDictionary[FormattingWord].Add(FormattingTranslate);
                    Console.WriteLine("еще один перевод слова добавлен!");
                }
                else
                {
                    _UserDictionary.Add(FormattingWord, new List<string>());
                    _UserDictionary[FormattingWord].Add(FormattingTranslate);
                    Console.WriteLine("в словарь добавлено новое слово и его перевод!");
                }
            }
            catch(ErrorCharExeption EX)
            {
                Console.WriteLine(EX.Val + " - " + EX.Message);
            }
            
        }       
        //для теста

        public void DelWord(string word)
        {
            if (IsContain(word))
            {
                _UserDictionary.Remove(word);
                Console.WriteLine($"Слово {word} удалено из словаря!");
            }
            else
            {
                Console.WriteLine($"в вашем словаре нет такого слова!");
            }
        }
        public void DelTranslate(string word, string translate)
        {

           // check(word, translate);
            if (_UserDictionary.ContainsKey(word))
            {
                if (_UserDictionary[word].Contains(translate) && _UserDictionary[word].Count > 1)
                    _UserDictionary[word].Remove(translate);
                else
                    Console.WriteLine(@"Невозможно удалить данный перевод, так как перевод единственный!");
            }
            else
            {
                Console.WriteLine("в словаре нет такого слова!");
            }

        }

        public void ChangeWord(string StringForChange)
        {
            
            if (_UserDictionary.ContainsKey(StringForChange))
                {
                try
                {
                    Console.WriteLine($"введите слово на которое заменить слово {StringForChange}");
                    string ChangedWord = Console.ReadLine();
                    CheckValueCorrect(ChangedWord);
                    List<string> NewValues = new List<string>();
                    foreach (var i in _UserDictionary[StringForChange])
                    {
                        NewValues.Add(i);
                    }
                    _UserDictionary.Remove(StringForChange);
                   
                    _UserDictionary.Add(ChangedWord, NewValues);
                    SaveInFile();
                }
                catch(Exception Ex)
                {
                    throw;
                }
                }
                else
                {
                    throw new ContainsElemExeption("не найдено такого слова в словаре для замены!");
                }            
        }
        public List<string> FindWord(string s)
        {
            List<string> UserWords = new List<string>();
            if (_UserDictionary.ContainsKey(s))
            {
                
                foreach(var w in _UserDictionary[s])
                {
                    UserWords.Add(w);
                }           
            }
            return UserWords;
        }
        public void ChangeTranslate(string word, string translate, string Newtranslate)
        {

            if (_UserDictionary.ContainsKey((word)) && (_UserDictionary[word].Contains(translate)))
            { 
                    _UserDictionary[word].Remove(translate);
                    _UserDictionary[word].Add(Newtranslate);
                }
            else
            {
                throw new ContainsElemExeption("в словаре нет такого перевода слова,которое вы хотите заменить");
            }
                    
        }

        public void ExportWord(string word,string name)
        {
            if (_UserDictionary.ContainsKey(word))
            {
                Dictionary<string, List<string>> dict2 = new Dictionary<string, List<string>>();
                dict2.Add(word, _UserDictionary[word]);
                try
                {
                    using (FileStream stream = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter sr = new StreamWriter(stream, Encoding.UTF8))
                        {

                            foreach (KeyValuePair<string, List<string>> k in dict2)
                            {
                                sr.Write(k.Key + '-');
                                foreach (var i in dict2[k.Key])
                                {
                                    sr.Write(i);
                                }
                                sr.WriteLine();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw;
                }
                Console.WriteLine($"слово {word}со всеми его переводами, успешно экспортировано в файл {name}");
                
            }
            else
            {
                throw new ContainsElemExeption("в данном словаре нет указанного слова");
            }
        }
        abstract public void CheckValuesCorrect(string word, string translate);
        abstract public void CheckValueCorrect(string word);
    }
}
