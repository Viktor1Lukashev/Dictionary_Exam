using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
   public interface Idict
    {
        public void SaveInFile();
       // public void SaveOld();
        public void AddToDictionary(string word, string translate);
        public void PrintDictionaryValues(); // - так же нарушение принципа RSP (осознанное)
        public void ChangeWord(string s);
        public List<string> FindWord(string s);
        //public void FindTranslate();
        public void ChangeTranslate(string Word, string Translate,string NewTranslate);
        public void DelTranslate(string word, string translate);
        public void DelWord(string word);
        //  public void check(string word, string translate);

        public void ExportWord(string word, string name); //-нарушение принципа solid (RSP) - но пошел на это осознанно, т.к. у нас один клиент класса 
        
    }
}
