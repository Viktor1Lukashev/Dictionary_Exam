using exam;
using exam.UserExeption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//добавить directoryinfo для проверки файла в каталоге при открытии или создании
namespace exam.WorkWithDictionary
{
    public class NewDictionary
    {
        public static void Create( /*Dict m1,*/ int number)
        {
            Idict MyDict;
            FactoryDict FactoryDictionary;
            Console.WriteLine("выберите словарь: ");
            Console.WriteLine("Англо-русский");
            Console.WriteLine("Русско-английский");
            Int32.TryParse(Console.ReadLine(), out int i);
            Console.WriteLine("напишите название вашего словаря: ");
            string path = Console.ReadLine();

            if (i == 1)
            {
                FactoryDictionary = new EnglishDictCreator();
                MyDict = FactoryDictionary.Create(path);

                // my = new RussianEnglish(path);

                Console.WriteLine("словарь создан!");
                Console.WriteLine("выберите действие со словарем: ");
                GeneralWorking.WorkWithDict(MyDict);
            }
            else if (i == 2)
            {
                FactoryDictionary = new RussianDictCreator();
                MyDict = FactoryDictionary.Create(path);

                // my = new RussianEnglish(path);

                Console.WriteLine("словарь создан!");
                Console.WriteLine("выберите действие со словарем: ");
                GeneralWorking.WorkWithDict(MyDict);
            }
            else {
                throw new ExeptionChoiseDictionary("увы, вы не можете выбрать данное действие. пожалуйста повторите!");  
            }
            
        }
    }
}

