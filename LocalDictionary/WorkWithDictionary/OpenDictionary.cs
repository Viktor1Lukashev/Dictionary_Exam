using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.WorkWithDictionary
{
   public class OpenDictionary
    {
        public static void Open(int result)
        {
           
         Console.WriteLine("введите название вашего словаря который необходимо открыть: ");
         string pathName = Console.ReadLine();
         switch (result)
            { 
             case 1:
                   try
                    {
                    FactoryDict Creator = new EnglishDictCreator();                        
                    Idict MyDict = Creator.Create(pathName);

                        Console.WriteLine("словарь открыт! вот его содержимое: ");
                        MyDict.PrintDictionaryValues();
                        GeneralWorking.WorkWithDict(MyDict);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                    
                    break;
                case 2:
                    try
                    {
                        FactoryDict Creator= new RussianDictCreator();
                        Idict MyDict = Creator.Create(pathName);

                        Console.WriteLine("словарь открыт! вот его содержимое: ");
                        MyDict.PrintDictionaryValues();
                        GeneralWorking.WorkWithDict(MyDict);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                    break;
            }
        }
    }
}
